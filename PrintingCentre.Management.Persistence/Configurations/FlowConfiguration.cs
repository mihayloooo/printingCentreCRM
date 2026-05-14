using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class FlowConfiguration : IEntityTypeConfiguration<Flow>
    {
        public void Configure(EntityTypeBuilder<Flow> builder)
        {
            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
