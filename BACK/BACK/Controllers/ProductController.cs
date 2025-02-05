using BACK.Models;
using BACK.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {

            try
            {
                List<Product> products = await _productRepository.GetProductsAsync();

                return Ok(products);

            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred while inserting the product: {ErrorMessage}", e.Message);
                return BadRequest(new
                {
                    code = HttpStatusCode.BadRequest,
                    message = "An error occurred while inserting the product."
                });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                Product product = await _productRepository.GetProductId(ObjectId.Parse(id));

                return Ok(product);

            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred while inserting the product: {ErrorMessage}", e.Message);
                return BadRequest(new
                {
                    code = HttpStatusCode.BadRequest,
                    message = "An error occurred while inserting the product."
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _productRepository.AddProdutc(product);
                return Ok(new
                {
                    code = HttpStatusCode.OK,
                    message = "Product inserted successfully"
                });

            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred while inserting the product: {ErrorMessage}", e.Message);
                return BadRequest(new
                {
                    code = HttpStatusCode.BadRequest,
                    message = "An error occurred while inserting the product."
                });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Product producto)
        {
            try
            {
                await _productRepository.UpdateProduct(ObjectId.Parse(id), producto);

                return Ok(new
                {
                    code = HttpStatusCode.OK,
                    message = "Product update suscefult."
                });


            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred while updating the room state:  {ErrorMessage}", e.Message);
                return BadRequest(new
                {
                    code = HttpStatusCode.BadRequest,
                    message = "An error occurred while updating the room state."
                });


            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _productRepository.DeleteProdutc(ObjectId.Parse(id));

                return Ok(new
                {
                    code = HttpStatusCode.OK,
                    message = "Product delete suscefult."
                });


            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred while updating the room state:  {ErrorMessage}", e.Message);
                return BadRequest(new
                {
                    code = HttpStatusCode.BadRequest,
                    message = "An error occurred while updating the room state."
                });


            }
        }
    }
}
