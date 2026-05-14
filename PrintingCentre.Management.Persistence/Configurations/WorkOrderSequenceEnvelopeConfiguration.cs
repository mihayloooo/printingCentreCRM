using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class WorkOrderSequenceEnvelopeConfiguration : IEntityTypeConfiguration<WorkOrderSequenceEnvelope>
    {
        public void Configure(EntityTypeBuilder<WorkOrderSequenceEnvelope> builder)
        {
            builder.HasOne(e => e.WorkOrderSequence)
                .WithMany(ws => ws.WorkOrderSequenceEnvelopes)
                .HasForeignKey(e => e.WorkOrderSequenceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Envelope)
                .WithMany(en => en.WorkOrderSequenceEnvelopes)
                .HasForeignKey(e => e.EnvelopeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
