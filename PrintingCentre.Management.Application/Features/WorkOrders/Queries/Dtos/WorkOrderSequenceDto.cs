namespace PrintingCentre.Management.Application.Features.WorkOrders.Queries.Dtos
{
    public class WorkOrderSequenceDto
    {
        public Guid Id { get; set; }
        public Guid FlowSequenceId { get; set; }
        public List<PrintTemplateDto> Templates { get; set; } = new();
        public List<EnvelopeDto> Envelopes { get; set; } = new();
    }
}
