using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Flows.Commands.UpdateFlow
{
    public class UpdateFlowCommandHandler : IRequestHandler<UpdateFlowCommand>
    {
        private readonly IFlowRepository _flowRepository;
        private readonly IMapper _mapper;

        public UpdateFlowCommandHandler(IFlowRepository flowRepository, IMapper mapper)
        {
            _flowRepository = flowRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateFlowCommand request, CancellationToken cancellationToken)
        {
            var flowToUpdate = await _flowRepository.GetByIdWithSequencesAsync(request.Id);

            if (flowToUpdate == null)
                throw new NotFoundException(nameof(Flow), request.Id);

            var validator = new UpdateFlowCommandValidator(_flowRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            foreach (var seq in request.FlowSequences)
            {
                seq.Templates.RemoveAll(t => t.PrintTemplateId == Guid.Empty);
                seq.Envelopes.RemoveAll(e => e.EnvelopeId == Guid.Empty);
            }

            flowToUpdate.Name = request.Name;
            flowToUpdate.Note = request.Note;

            var newSequences = _mapper.Map<List<FlowSequence>>(request.FlowSequences);
            foreach (var seq in newSequences)
            {
                seq.FlowId = flowToUpdate.Id;
                foreach (var tmpl in seq.FlowSequencePrintTemplates)
                    tmpl.FlowSequenceId = seq.Id;
                foreach (var env in seq.FlowSequenceEnvelopes)
                    env.FlowSequenceId = seq.Id;
            }

            await _flowRepository.ReplaceSequencesAsync(flowToUpdate, newSequences);
        }
    }
}
