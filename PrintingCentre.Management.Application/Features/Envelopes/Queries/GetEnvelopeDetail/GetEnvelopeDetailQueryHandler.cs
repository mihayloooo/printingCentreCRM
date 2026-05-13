using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopeDetail
{
    public class GetEnvelopeDetailQueryHandler : IRequestHandler<GetEnvelopeDetailQuery, EnvelopeDetailVm>
    {
        private readonly IEnvelopeRepository _envelopeRepository;
        private readonly IMapper _mapper;

        public GetEnvelopeDetailQueryHandler(IMapper mapper, IEnvelopeRepository envelopeRepository)
        {
            _mapper = mapper;
            _envelopeRepository = envelopeRepository;
        }

        public async Task<EnvelopeDetailVm> Handle(GetEnvelopeDetailQuery request, CancellationToken cancellationToken)
        {
            var envelope = await _envelopeRepository.GetByIdAsync(request.Id);

            if (envelope == null)
            {
                throw new NotFoundException(nameof(Envelope), request.Id);
            }

            return _mapper.Map<EnvelopeDetailVm>(envelope);
        }
    }
}

