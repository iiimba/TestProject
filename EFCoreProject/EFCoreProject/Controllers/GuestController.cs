using System.Linq;
using EFCoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
    {
        private DataContext context;

        public GuestController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var responses = context.Responses.OrderByDescending(r => r.WillAttend);

            return Ok(responses);
        }

        [HttpPost]
        public IActionResult Create(GuestResponse response)
        {
            context.Responses.Add(response);
            context.SaveChanges();

            return Ok(new 
            {
                response.Id,
                response.Name
            });
        }
    }
}
