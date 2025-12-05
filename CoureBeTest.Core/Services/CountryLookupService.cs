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

        public async Task<object?> LookupByPhone(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 3)
                return null;

            var code = phoneNumber[..3];

            var country = await _unitOfWork.Countries
                            .AsQueryable()
                            .Include(x => x.CountryDetails)
                            .FirstOrDefaultAsync(x => x.CountryCode == code);

            if (country == null)
                return null;

            return new
            {
                number = phoneNumber,
                country = new
                {
                    country.CountryCode,
                    country.Name,
                    country.CountryIso,
                    countryDetails = country.CountryDetails.Select(x => new
                    {
                        x.Operator,
                        x.OperatorCode
                    })
                }
            };
        }
    }
}
