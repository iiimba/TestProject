using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierValuesController : ControllerBase
    {
        private ISupplierRepository repository;

        public SupplierValuesController(ISupplierRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetContactDetails()
        {
            var suppliers = this.repository.GetAll();
            return Ok(suppliers);
        }
    }
}
