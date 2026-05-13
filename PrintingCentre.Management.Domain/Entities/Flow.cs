using PrintingCentre.Management.Domain.Common;

namespace PrintingCentre.Management.Domain.Entities
{
    public class Flow : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }

        public ICollection<FlowSequence> FlowSequences { get; set; } = default!;

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = default!;
    }
}
