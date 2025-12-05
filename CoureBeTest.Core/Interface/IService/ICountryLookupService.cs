namespace CoureBeTest.Core.Interface.IServices
{
    public interface ICountryLookupService
    {
        Task<object?> LookupByPhone(string phoneNumber);
    }
}
