using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Contracts.Persistence
{
    public interface IPrintTemplateRepository : IAsyncRepository<PrintTemplate>
    {
    }
}

