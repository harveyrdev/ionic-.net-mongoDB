using BACK.Models;
using BACK.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;


        public OrderController(IOrderRepository ordenRepository)
        {
            _orderRepository = ordenRepository;
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var ordenes = await _orderRepository.GetOrders();
            return Ok(ordenes);
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] Order order)
        {





            try
            {


                await _orderRepository.NewOrder(order);
                return Ok(new
                {
                    code = HttpStatusCode.OK,
                    message = "Order inserted successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    code = HttpStatusCode.BadRequest,
                    message = "An error occurred while inserting the reservation."
                });
            }
        }


    }
}
