using BACK.Models;

namespace BACK.Repositories.Interfaces
{
    public interface IOrderRepository
    {

        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(string id);
        Task NewOrder(Order order);
    }
}
