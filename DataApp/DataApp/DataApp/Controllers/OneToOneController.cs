using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OneToOneController : ControllerBase
    {
        private DataContext context;

        public OneToOneController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var suppliers = this.context.Suppliers.Include(s => s.Contact).ToList();
            //return Ok(suppliers);

            //var contacts = this.context.Set<ContactDetails>().Include(s => s.Supplier).ToList();


            //var details = this.context.Set<ContactDetails>().Include(s => s.Supplier).First(d => d.Id == 3);
            //details.SupplierId = 1;
            //this.context.SaveChanges();

            //var details = this.context.Suppliers.Include(s => s.Contact).First(d => d.Id == 2);
            //details.Contact.SupplierId = 3;

            //var details2 = this.context.Suppliers.Include(s => s.Contact).First(d => d.Id == 3);
            //details2.Contact.SupplierId = 2;


            var contacts1 = this.context.Set<ContactDetails>().Include(s => s.Supplier).First(c => c.Id == 1);
            contacts1.SupplierId = 3;

            this.context.SaveChanges();

            var contacts2 = this.context.Set<ContactDetails>().Include(s => s.Supplier).First(c => c.Id == 3);
            contacts2.SupplierId = 2;

            this.context.SaveChanges();


            return Ok();
        }
    }
}
