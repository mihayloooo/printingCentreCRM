using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class WorkOrderSequenceConfiguration : IEntityTypeConfiguration<WorkOrderSequence>
    {
        public void Configure(EntityTypeBuilder<WorkOrderSequence> builder)
        {
            builder.HasOne(ws => ws.WorkOrder)
                .WithMany(w => w.WorkOrderSequences)
                .HasForeignKey(ws => ws.WorkOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ws => ws.FlowSequence)
                .WithMany(fs => fs.WorkOrderSequences)
                .HasForeignKey(ws => ws.FlowSequenceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
