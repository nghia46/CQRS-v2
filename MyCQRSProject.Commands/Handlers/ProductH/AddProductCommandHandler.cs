using MediatR;
using MyCQRSProject.Commands.Commands.ProductC;
using MyCQRSProject.Domain.Entities;
using MyCQRSProject.Domain.Interfaces;

namespace MyCQRSProject.Commands.Handlers.ProductH;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public AddProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Product.Name,
            Price = request.Product.Price,
            Stock = request.Product.Stock,
            CreatedAt = DateTime.Now
        };
        return _productRepository.AddProductAsync(product);
    }
}