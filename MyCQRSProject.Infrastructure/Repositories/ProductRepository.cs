using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MyCQRSProject.Domain.Entities;
using MyCQRSProject.Domain.Interfaces;

namespace MyCQRSProject.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        var databaseName = configuration.GetSection("MongoDb:DatabaseName:CQRSdb").Value;
        var database = mongoClient.GetDatabase(databaseName);
        _productCollection = database.GetCollection<Product>(nameof(Product));
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productCollection.Find(p => true).ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        return await _productCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public Task<bool> AddProductAsync(Product product)
    {
        return Task.Run(() =>
        {
            _productCollection.InsertOne(product);
            return true;
        });
    }
}