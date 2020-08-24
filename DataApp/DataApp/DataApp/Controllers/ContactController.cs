using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        IGenericRepository<ContactDetails> contactDetailsRepository;
        IGenericRepository<ContactLocation> contactLocationRepository;

        public ContactController(IGenericRepository<ContactDetails> contactDetailsRepository, IGenericRepository<ContactLocation> contactLocationRepository)
        {
            this.contactDetailsRepository = contactDetailsRepository;
            this.contactLocationRepository = contactLocationRepository;
        }

        [HttpGet("Details")]
        public IActionResult GetContactDetails()
        {
            var contactDetails = this.contactDetailsRepository.GetAll();
            return Ok(contactDetails);
        }

        [HttpGet("Locations")]
        public IActionResult GetContactLocations()
        {
            var contactLocations = this.contactLocationRepository.GetAll();
            return Ok(contactLocations);
        }
    }
}
