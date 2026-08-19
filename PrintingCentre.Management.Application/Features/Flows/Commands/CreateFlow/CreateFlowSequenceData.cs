using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Flows.Commands.CreateFlow
{
    public class CreateFlowSequenceData
    {
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public PrintSide PrintSide { get; set; }
        public ColorMode ColorMode { get; set; }
        public ShipmentType ShipmentType { get; set; }

        public List<CreateFlowSequenceTemplateData> Templates { get; set; } = new();
        public List<CreateFlowSequenceEnvelopeData> Envelopes { get; set; } = new();

    }
}
