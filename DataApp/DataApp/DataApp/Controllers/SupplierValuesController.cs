using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult GetSuppliers()
        {
            var suppliers = this.repository.GetAll();
            return Ok(suppliers.Select(s => new 
            {
                s.Id,
                s.Name,
                s.City,
                s.State,
                s.Contact,
                sdd = s.Products?.Select(p => new 
                {
                    p.Id,
                    p.Name
                })
            }));
        }

        [HttpPost]
        public IActionResult CreateSupplier(Supplier supplier)
        {
            this.repository.Create(supplier);
            return Ok(supplier.Id);
        }

        [HttpPut]
        public IActionResult UpdateSupplier(Supplier supplier)
        {
            this.repository.Update(supplier);
            return Ok();
        }
    }
}
