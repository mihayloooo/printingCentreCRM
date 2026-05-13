using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class EnvelopeConfiguration : IEntityTypeConfiguration<Envelope>
    {
        public void Configure(EntityTypeBuilder<Envelope> builder)
        {
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}

