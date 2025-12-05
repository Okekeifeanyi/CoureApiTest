using Microsoft.AspNetCore.Mvc;
using CoureBeTest.Core.Interface.IServices;

namespace CoureBeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryLookupController : ControllerBase
    {
        private readonly ICountryLookupService _service;

        public CountryLookupController(ICountryLookupService service)
        {
            _service = service;
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetPhoneDetails(string phoneNumber)
        {
            var response = await _service.LookupByPhone(phoneNumber);

            if (response == null)
                return NotFound("Country code not recognized.");

            return Ok(response);
        }
    }
}
