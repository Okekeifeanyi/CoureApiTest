using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CoureBeTest.Core.Interface;
using CoureBeTest.Core.Interface.IRepositories;
using CoureBeTest.Core.Interface.IServices;
using CoureBeTest.Data.Repositories;
using CoureBeTest.Service;
using CoureBeTest.Data.DataBases;

namespace CoureBeTest.Data
{
    public static class DiExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CourDb>(options =>
                options.UseInMemoryDatabase("InMemoryCountryDb")
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICountryLookupService, CountryLookupService>();

            return services;
        }
    }
}
