using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Envelopes.Commands.CreateEnvelope
{
    public class CreateEnvelopeCommandHandler : IRequestHandler<CreateEnvelopeCommand, Guid>
    {
        private readonly IEnvelopeRepository _envelopeRepository;
        private readonly IMapper _mapper;

        public CreateEnvelopeCommandHandler(IEnvelopeRepository envelopeRepository, IMapper mapper)
        {
            _envelopeRepository = envelopeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEnvelopeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEnvelopeCommandValidator(_envelopeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var envelope = _mapper.Map<Envelope>(request);

            await _envelopeRepository.AddAsync(envelope);

            return envelope.Id;
        }
    }
}

