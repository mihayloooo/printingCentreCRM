using PrintingCentre.Management.Application.Features.Flows.Queries.Dtos;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowDetail
{
    public class FlowDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public Guid CompanyId { get; set; }
        public List<FlowSequenceDto> FlowSequences { get; set; } = new();
    }
}
