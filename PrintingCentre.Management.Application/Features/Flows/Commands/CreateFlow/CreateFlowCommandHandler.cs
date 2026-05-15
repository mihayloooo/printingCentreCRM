using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Flows.Commands.CreateFlow
{
    public class CreateFlowCommandHandler : IRequestHandler<CreateFlowCommand, Guid>
    {
        private readonly IFlowRepository _flowRepository;
        private readonly IMapper _mapper;

        public CreateFlowCommandHandler(IFlowRepository flowRepository, IMapper mapper)
        {
            _flowRepository = flowRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateFlowCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFlowCommandValidator(_flowRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            // Strip unselected (Guid.Empty) dropdown entries before mapping
            foreach (var seq in request.FlowSequences)
            {
                seq.Templates.RemoveAll(t => t.PrintTemplateId == Guid.Empty);
                seq.Envelopes.RemoveAll(e => e.EnvelopeId == Guid.Empty);
            }

            var flow = _mapper.Map<Flow>(request);

            await _flowRepository.AddAsync(flow);

            return flow.Id;
        }
    }
}
