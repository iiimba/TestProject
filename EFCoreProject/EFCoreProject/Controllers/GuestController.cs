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

        [HttpGet("{phone}")]
        public IActionResult Get(string phone)
        {
            var responses = context.Responses
                .Where(r => r.Phone == phone)
                .OrderBy(r => r.Email);

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
