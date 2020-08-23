using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DataApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductValuesController : ControllerBase
    {
        private IProductRepository repository;

        public ProductValuesController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this.repository.Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(long id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var product = this.repository.GetProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (product.Id != default)
            {
                return BadRequest();
            }

            this.repository.CreateProduct(product);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            if (product.Id < 1)
            {
                return BadRequest();
            }

            var existingProduct = this.repository.GetProduct(product.Id);
            if (existingProduct == null)
            {
                return BadRequest();
            }

            this.repository.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(long id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var existingProduct = this.repository.GetProduct(id);
            if (existingProduct == null)
            {
                return BadRequest();
            }

            this.repository.DeleteProduct(existingProduct);
            return Ok();
        }
    }
}
