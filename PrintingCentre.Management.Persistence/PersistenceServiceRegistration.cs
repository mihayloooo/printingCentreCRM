using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Persistence.Repositories;

namespace PrintingCentre.Management.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PrintingCentreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PrintingCentreConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IPrintTemplateRepository, PrintTemplateRepository>();
            services.AddScoped<IEnvelopeRepository, EnvelopeRepository>();

            return services;
        }
    }
}
