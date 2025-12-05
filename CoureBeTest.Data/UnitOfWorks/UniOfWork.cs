using CoureBeTest.Core.Interface;
using CoureBeTest.Core.Interface.IRepositories;
using CoureBeTest.Data.DataBases;
using CoureBeTest.Data.Repositories;
using CoureBeTest.Model;
using CoureBeTest.Model.Entities;

namespace CoureBeTest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CourDb _context;
        private bool _disposed;

        public IGenericRepository<Country> Countries { get; }
        public IGenericRepository<CountryDetail> CountryDetails { get; }

        public UnitOfWork(CourDb context)
        {
            _context = context;
            Countries = new GenericRepository<Country>(_context);
            CountryDetails = new GenericRepository<CountryDetail>(_context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
