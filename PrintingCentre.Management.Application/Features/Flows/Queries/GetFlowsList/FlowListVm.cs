using PrintingCentre.Management.Application.Features.Flows.Queries.Dtos;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsList
{
    public class FlowListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public Guid CompanyId { get; set; }
        public List<FlowSequenceDto> FlowSequences { get; set; } = new();
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
