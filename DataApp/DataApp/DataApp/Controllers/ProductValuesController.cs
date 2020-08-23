using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductValuesController : ControllerBase
    {
        private DataContext context;

        protected ProductValuesController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this.context.Products);
        }
    }
}
