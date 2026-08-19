using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Commands.UpdateFlowSequence
{
    public class UpdateFlowSequenceCommandHandler : IRequestHandler<UpdateFlowSequenceCommand>
    {
        private readonly IFlowSequenceRepository _flowSequenceRepository;
        private readonly IMapper _mapper;

        public UpdateFlowSequenceCommandHandler(IFlowSequenceRepository flowSequenceRepository, IMapper mapper)
        {
            _flowSequenceRepository = flowSequenceRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateFlowSequenceCommand request, CancellationToken cancellationToken)
        {
            var flowSequenceToUpdate = await _flowSequenceRepository.GetByIdAsync(request.Id);

            if (flowSequenceToUpdate == null)
                throw new NotFoundException(nameof(FlowSequence), request.Id);

            var validator = new UpdateFlowSequenceCommandValidator(_flowSequenceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, flowSequenceToUpdate, typeof(UpdateFlowSequenceCommand), typeof(FlowSequence));

            await _flowSequenceRepository.UpdateAsync(flowSequenceToUpdate);
        }
    }
}
