using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Repositories
{
    public class EnvelopeRepository : BaseRepository<Envelope>, IEnvelopeRepository
    {
        public EnvelopeRepository(PrintingCentreDbContext dbContext) : base(dbContext)
        {
        }
    }
}

