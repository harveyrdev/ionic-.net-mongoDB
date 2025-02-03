using BACK.Models;
using BACK.Repositories.Interfaces;
using BACK.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BACK.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _Products;

        public ProductRepository(MongoDbContext context)
        {
            _Products = context.Products;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _Products.Find(p => true).ToListAsync();
        }

        public Task<Product> GetProductId(ObjectId id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.DatabaseId, id);
            var productt = _Products.Find(filter).FirstOrDefaultAsync();
            return productt;
        }

        public async Task AddProdutc(Product producto)
        {
            await _Products.InsertOneAsync(producto);
        }

        public async Task UpdateProduct(ObjectId id, Product producto)
        {

            var filter = Builders<Product>.Filter.Eq(x => x.DatabaseId, id);
            var update = Builders<Product>.Update
                .Set(x => x.Name, producto.Name)
                .Set(x => x.Price, producto.Price)
                .Set(x => x.Stock, producto.Stock)
                .Set(x => x.Description, producto.Description)

                ;
            await _Products.UpdateOneAsync(filter, update);
        }

        public async Task DeleteProdutc(ObjectId id)



        {
            var filter = Builders<Product>.Filter.Eq(x => x.DatabaseId, id);
            await _Products.DeleteOneAsync(filter);
        }





    }
}
