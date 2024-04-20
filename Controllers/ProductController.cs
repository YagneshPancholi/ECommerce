using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.Services;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            try
            {
                return Ok(await _service.GetProductList());
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _service.GetProductById(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            try
            {
                var response = await _service.GetProductById(id);

                if (response == null)
                {
                    return NotFound();
                }
                product.Id = response.Id;
                var result = await _service.UpdateProduct(product);

                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            try
            {
                var result = await _service.CreateProduct(product);

                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var response = await _service.GetProductById(id);

                if (response == null)
                {
                    return NotFound();
                }
                var result = await _service.DeleteProduct(id);

                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

    }
}
