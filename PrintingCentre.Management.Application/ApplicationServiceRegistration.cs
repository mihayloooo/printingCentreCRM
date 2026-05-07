using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany;

namespace PrintingCentre.Management.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddValidatorsFromAssemblyContaining<UpdateCompanyCommandValidator>();

            return services;
        }
    }
}
