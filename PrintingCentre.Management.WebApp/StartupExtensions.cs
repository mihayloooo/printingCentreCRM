using PrintingCentre.Management.Application;
using PrintingCentre.Management.Persistence;

namespace PrintingCentre.Management.WebApp
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            return builder.Build();
        }
    }
}
