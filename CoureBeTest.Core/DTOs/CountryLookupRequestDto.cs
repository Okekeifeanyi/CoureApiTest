using System.ComponentModel.DataAnnotations;

namespace CoureBeTest.API.DTOs
{
    public class CountryLookupRequestDto
    {
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
