using CoureBeTest.Core.Interface;
using CoureBeTest.Core.Interface.IServices;
using Microsoft.EntityFrameworkCore;

namespace CoureBeTest.Service
{
    public class CountryLookupService : ICountryLookupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryLookupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CountryLookupResponseDto?> LookupByPhone(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 3 || !phoneNumber.All(char.IsDigit))
                return null;

            var code = phoneNumber[..3];

            var country = await _unitOfWork.Countries
                            .AsQueryable()
                            .Include(x => x.CountryDetails)
                            .FirstOrDefaultAsync(x => x.CountryCode == code);

            if (country == null)
                return null;

            return new CountryLookupResponseDto
            {
                Number = phoneNumber,
                Country = new CountryDto
                {
                    CountryCode = country.CountryCode,
                    Name = country.Name,
                    CountryIso = country.CountryIso,
                    CountryDetails = country.CountryDetails.Select(x => new OperatorDto
                    {
                        Operator = x.Operator,
                        OperatorCode = x.OperatorCode
                    }).ToList()
                }
            };
        }
    }
}
