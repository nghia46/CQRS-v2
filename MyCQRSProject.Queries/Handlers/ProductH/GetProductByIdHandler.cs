using MediatR;
using MyCQRSProject.Domain.Entities;
using MyCQRSProject.Domain.Interfaces;
using MyCQRSProject.Queries.Queries.ProductQ;

namespace MyCQRSProject.Queries.Handlers.ProductH;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return _productRepository.GetProductByIdAsync(request.Id);
    }
}