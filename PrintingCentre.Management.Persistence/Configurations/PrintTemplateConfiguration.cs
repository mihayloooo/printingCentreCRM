using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class PrintTemplateConfiguration : IEntityTypeConfiguration<PrintTemplate>
    {
        public void Configure(EntityTypeBuilder<PrintTemplate> builder)
        {
                builder.Property(pt => pt.Code)
                    .IsRequired()
                    .HasMaxLength(12);
        }
    }
}
