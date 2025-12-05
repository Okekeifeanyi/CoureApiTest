using CoureBeTest.Core.Interface.IRepositories;
using CoureBeTest.Model;
using CoureBeTest.Model.Entities;
using System;
using System.Threading.Tasks;

namespace CoureBeTest.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<CountryDetail> CountryDetails { get; }

        Task<int> SaveAsync();
    }
}
