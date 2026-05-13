using Microsoft.EntityFrameworkCore;
using PrintingCentre.Management.Domain.Common;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence
{
    public class PrintingCentreDbContext : DbContext
    {
        public PrintingCentreDbContext(DbContextOptions<PrintingCentreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<PrintTemplate> PrintTemplates { get; set; }
        public DbSet<Envelope> Envelopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrintingCentreDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        //entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        //entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
