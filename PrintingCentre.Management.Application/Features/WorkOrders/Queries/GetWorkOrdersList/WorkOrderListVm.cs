using PrintingCentre.Management.Application.Features.WorkOrders.Queries.Dtos;

namespace PrintingCentre.Management.Application.Features.WorkOrders.Queries.GetWorkOrdersList
{
    public class WorkOrderListVm
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public Guid FlowId { get; set; }
        public List<WorkOrderSequenceDto> WorkOrderSequences { get; set; } = new();
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
