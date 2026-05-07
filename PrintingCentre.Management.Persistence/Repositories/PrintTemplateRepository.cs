using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Repositories
{
    public class PrintTemplateRepository : BaseRepository<PrintTemplate>, IPrintTemplateRepository
    {
        public PrintTemplateRepository(PrintingCentreDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsPrintTemplateCodeUnique(string code)
        {
            var matches = _dbContext.PrintTemplates.Any(pt => pt.Code.Equals(code));
            return Task.FromResult(matches);
        }

        public Task<bool> IsPrintTemplateCodeUnique(string code, Guid excludeId)
        {
            var matches = _dbContext.PrintTemplates.Any(pt => pt.Code.Equals(code) && pt.Id != excludeId);
            return Task.FromResult(matches);
        }
    }
}

