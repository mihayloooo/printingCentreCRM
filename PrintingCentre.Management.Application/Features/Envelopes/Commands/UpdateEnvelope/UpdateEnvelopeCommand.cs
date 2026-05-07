using MediatR;

namespace PrintingCentre.Management.Application.Features.Envelopes.Commands.UpdateEnvelope
{
    public class UpdateEnvelopeCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string EnvelopeUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public bool IsActive { get; set; }
    }
}

