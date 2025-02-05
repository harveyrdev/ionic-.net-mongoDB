using BACK.Models;
using MongoDB.Driver;

namespace BACK.Services
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("APPMOTOSDB");
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Product");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Order");
    }
}
