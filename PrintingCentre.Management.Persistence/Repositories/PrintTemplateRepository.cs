using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Repositories
{
    public class PrintTemplateRepository : BaseRepository<PrintTemplate>, IPrintTemplateRepository
    {
        public PrintTemplateRepository(PrintingCentreDbContext dbContext) : base(dbContext)
        {
        }
    }
}

