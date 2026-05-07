using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Envelopes.Commands.UpdateEnvelope
{
    public class UpdateEnvelopeCommandHandler : IRequestHandler<UpdateEnvelopeCommand>
    {
        private readonly IEnvelopeRepository _envelopeRepository;
        private readonly IMapper _mapper;

        public UpdateEnvelopeCommandHandler(IEnvelopeRepository envelopeRepository, IMapper mapper)
        {
            _envelopeRepository = envelopeRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEnvelopeCommand request, CancellationToken cancellationToken)
        {
            var envelopeToUpdate = await _envelopeRepository.GetByIdAsync(request.Id);

            if (envelopeToUpdate == null)
            {
                throw new NotFoundException(nameof(Envelope), request.Id);
            }

            var validator = new UpdateEnvelopeCommandValidator(_envelopeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, envelopeToUpdate, typeof(UpdateEnvelopeCommand), typeof(Envelope));

            await _envelopeRepository.UpdateAsync(envelopeToUpdate);
        }
    }
}

