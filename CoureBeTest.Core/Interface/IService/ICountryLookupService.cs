namespace CoureBeTest.Core.Interface.IServices
{
    public interface ICountryLookupService
    {
        Task<CountryLookupResponseDto?> LookupByPhone(string phoneNumber);
    }
}
