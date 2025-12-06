using CoureBeTest.Model.Entities;

namespace CoureBeTest.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<CountryDetail> CountryDetails { get; }

        Task<int> SaveAsync();
    }
}
