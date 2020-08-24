using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactValuesController : ControllerBase
    {
        IGenericRepository<ContactDetails> contactDetailsRepository;
        IGenericRepository<ContactLocation> contactLocationRepository;

        public ContactValuesController(IGenericRepository<ContactDetails> contactDetailsRepository, IGenericRepository<ContactLocation> contactLocationRepository)
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
