using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToUpdate = await _companyRepository.GetByIdAsync(request.CompanyId);

            if (companyToUpdate == null)
            {
                throw new NotFoundException(nameof(Company), request.CompanyId);
            }

            var validator = new UpdateCompanyCommandValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            _mapper.Map(request, companyToUpdate, typeof(UpdateCompanyCommand), typeof(Company));

            await _companyRepository.UpdateAsync(companyToUpdate);
        }
    }
}
