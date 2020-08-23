using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedDataController : ControllerBase
    {
        private DataContext dataContext;
        private CustomerContext customerContext;

        public SeedDataController(DataContext dataContext, CustomerContext customerContext)
        {
            this.dataContext = dataContext;
            this.customerContext = customerContext;
        }

        [HttpPost("Seed")]
        public IActionResult Seed()
        {
            DataSeed.Seed(dataContext);
            DataSeed.Seed(customerContext);

            return Ok();
        }
    }
}
