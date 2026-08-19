using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class FlowSequenceEnvelopeConfiguration : IEntityTypeConfiguration<FlowSequenceEnvelope>
    {
        public void Configure(EntityTypeBuilder<FlowSequenceEnvelope> builder)
        {
            builder.HasOne(fse => fse.FlowSequence)
                .WithMany(fs => fs.FlowSequenceEnvelopes)
                .HasForeignKey(fse => fse.FlowSequenceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fse => fse.Envelope)
                .WithMany(e => e.FlowSequenceEnvelopes)
                .HasForeignKey(fse => fse.EnvelopeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
