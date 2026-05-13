using PrintingCentre.Management.Domain.Common;

namespace PrintingCentre.Management.Domain.Entities
{
    public class WorkOrder : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;

        public Guid FlowId { get; set; }
        public Flow Flow { get; set; } = null!;

        public ICollection<WorkOrderSequence> WorkOrderSequences { get; set; } = default!;
    }
}
