using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Repositories
{
    public class EnvelopeRepository : BaseRepository<Envelope>, IEnvelopeRepository
    {
        public EnvelopeRepository(PrintingCentreDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEnvelopeCodeUnique(string code)
        {
            var matches = _dbContext.Envelopes.Any(e => e.Code.Equals(code));
            return Task.FromResult(matches);
        }

        public Task<bool> IsEnvelopeCodeUnique(string code, Guid excludeId)
        {
            var matches = _dbContext.Envelopes.Any(e => e.Code.Equals(code) && e.Id != excludeId);
            return Task.FromResult(matches);
        }
    }
}

