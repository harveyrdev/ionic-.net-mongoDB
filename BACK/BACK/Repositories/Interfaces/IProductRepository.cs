using BACK.Models;
using MongoDB.Bson;

namespace BACK.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductId(ObjectId productId);
        Task AddProdutc(Product product);
        Task DeleteProdutc(ObjectId productId);
        Task UpdateProduct(ObjectId productId, Product product);

    }
}
