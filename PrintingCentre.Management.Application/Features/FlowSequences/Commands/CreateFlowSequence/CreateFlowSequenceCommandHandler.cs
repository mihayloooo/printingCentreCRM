using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Commands.CreateFlowSequence
{
    public class CreateFlowSequenceCommandHandler : IRequestHandler<CreateFlowSequenceCommand, Guid>
    {
        private readonly IFlowSequenceRepository _flowSequenceRepository;
        private readonly IMapper _mapper;

        public CreateFlowSequenceCommandHandler(IFlowSequenceRepository flowSequenceRepository, IMapper mapper)
        {
            _flowSequenceRepository = flowSequenceRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateFlowSequenceCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFlowSequenceCommandValidator(_flowSequenceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var flowSequence = _mapper.Map<FlowSequence>(request);

            await _flowSequenceRepository.AddAsync(flowSequence);

            return flowSequence.Id;
        }
    }
}
