using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class FlowSequenceConfiguration : IEntityTypeConfiguration<FlowSequence>
    {
        public void Configure(EntityTypeBuilder<FlowSequence> builder)
        {
            builder.Property(fs => fs.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(fs => fs.PrintSide)
                .HasConversion<string>();

            builder.Property(fs => fs.ColorMode)
                .HasConversion<string>();

            builder.Property(fs => fs.ShipmentType)
                .HasConversion<string>();
        }
    }
}
