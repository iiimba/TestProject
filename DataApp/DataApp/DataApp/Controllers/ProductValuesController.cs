using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new Product[] 
            {
                new Product { Name = "Ball", Category = "Sport", Price = 200 },
                new Product { Name = "Apple", Category = "Fruit", Price = 1 }
            };

            return Ok(products);
        }
    }
}
