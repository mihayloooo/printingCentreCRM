using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Configurations
{
    public class FlowSequencePrintTemplateConfiguration : IEntityTypeConfiguration<FlowSequencePrintTemplate>
    {
        public void Configure(EntityTypeBuilder<FlowSequencePrintTemplate> builder)
        {
            builder.HasOne(fspt => fspt.FlowSequence)
                .WithMany(fs => fs.FlowSequencePrintTemplates)
                .HasForeignKey(fspt => fspt.FlowSequenceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fspt => fspt.PrintTemplate)
                .WithMany(pt => pt.FlowSequencePrintTemplates)
                .HasForeignKey(fspt => fspt.PrintTemplateId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
