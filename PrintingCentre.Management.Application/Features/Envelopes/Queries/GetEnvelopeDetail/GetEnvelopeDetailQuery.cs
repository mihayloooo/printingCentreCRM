using MediatR;

namespace PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopeDetail
{
    public class GetEnvelopeDetailQuery : IRequest<EnvelopeDetailVm>
    {
        public Guid Id { get; set; }
    }
}

