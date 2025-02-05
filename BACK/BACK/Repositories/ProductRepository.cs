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
            return await _Products.Find(_ => true).ToListAsync();
        }

        public Task<Product> GetProductId(ObjectId id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.databaseId, id);
            var productt = _Products.Find(filter).FirstOrDefaultAsync();
            return productt;
        }

        public async Task AddProdutc(Product producto)
        {
            await _Products.InsertOneAsync(producto);
        }

        public async Task UpdateProduct(ObjectId id, Product producto)
        {

            var filter = Builders<Product>.Filter.Eq(x => x.databaseId, id);
            var update = Builders<Product>.Update
                .Set(x => x.name, producto.name)
                .Set(x => x.price, producto.price)
                .Set(x => x.stock, producto.stock)
                .Set(x => x.description, producto.description)

                ;
            await _Products.UpdateOneAsync(filter, update);
        }

        public async Task DeleteProdutc(ObjectId id)



        {
            var filter = Builders<Product>.Filter.Eq(x => x.databaseId, id);
            await _Products.DeleteOneAsync(filter);
        }





    }
}
