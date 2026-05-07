using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(PrintingCentreDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsCompanyCodeUnique(string code)
        {
            var matches = _dbContext.Companies.Any(c => c.Code.Equals(code));
            return Task.FromResult(matches);
        }
    }
}
