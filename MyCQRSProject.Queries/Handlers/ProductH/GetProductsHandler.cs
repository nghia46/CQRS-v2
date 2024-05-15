using MediatR;
using MyCQRSProject.Domain.Entities;
using MyCQRSProject.Domain.Interfaces;
using MyCQRSProject.Queries.Queries.ProductQ;

namespace MyCQRSProject.Queries.Handlers.ProductH;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;
    public GetProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return _productRepository.GetProductsAsync();
    }
}