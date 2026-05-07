using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Contracts.Persistence
{
    public interface IPrintTemplateRepository : IAsyncRepository<PrintTemplate>
    {
        // Kept consistent with existing Company logic:
        // returns true when a record with the same code already exists.
        Task<bool> IsPrintTemplateCodeUnique(string code);
        Task<bool> IsPrintTemplateCodeUnique(string code, Guid excludeId);
    }
}

