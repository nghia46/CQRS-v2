using MyCQRSProject.Domain.Entities;

namespace MyCQRSProject.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(Guid id);
    Task<bool> AddProductAsync(Product product);
}