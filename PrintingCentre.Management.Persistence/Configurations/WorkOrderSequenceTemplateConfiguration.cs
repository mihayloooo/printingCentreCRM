using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class WorkOrderSequenceTemplateConfiguration : IEntityTypeConfiguration<WorkOrderSequenceTemplate>
    {
        public void Configure(EntityTypeBuilder<WorkOrderSequenceTemplate> builder)
        {
            builder.HasOne(t => t.WorkOrderSequence)
                .WithMany(ws => ws.WorkOrderSequenceTemplates)
                .HasForeignKey(t => t.WorkOrderSequenceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.PrintTemplate)
                .WithMany(p => p.WorkOrderSequenceTemplates)
                .HasForeignKey(t => t.PrintTemplateId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
