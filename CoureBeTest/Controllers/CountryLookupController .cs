using CoureBeTest.API.DTOs;
using CoureBeTest.Core.Interface.IServices;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetPhoneDetails([FromQuery] CountryLookupRequestDto request)
        {
            var response = await _service.LookupByPhone(request.PhoneNumber);

            if (response == null)
                return NotFound("Country code not recognized.");

            return Ok(response);
        }
    }
}
