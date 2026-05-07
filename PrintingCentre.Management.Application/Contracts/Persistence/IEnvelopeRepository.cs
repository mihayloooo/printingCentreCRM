using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Contracts.Persistence
{
    public interface IEnvelopeRepository : IAsyncRepository<Envelope>
    {
        // Kept consistent with existing Company logic:
        // returns true when a record with the same code already exists.
        Task<bool> IsEnvelopeCodeUnique(string code);
        Task<bool> IsEnvelopeCodeUnique(string code, Guid excludeId);
    }
}

