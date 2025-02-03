using BACK.Models;
using BACK.Repositories.Interfaces;
using BACK.Services;
using MongoDB.Driver;

namespace BACK.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly IMongoCollection<Order> _orders;

        public OrderRepository(MongoDbContext context)
        {
            _orders = context.Orders;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orders.Find(o => true).ToListAsync();
        }

        public async Task<Order> GetOrderById(string id)
        {
            return await _orders.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task NewOrder(Order order)
        {
            await _orders.InsertOneAsync(order);
        }


    }
}
