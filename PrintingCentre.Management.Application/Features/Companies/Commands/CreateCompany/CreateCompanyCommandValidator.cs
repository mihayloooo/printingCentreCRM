using FluentValidation;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandValidator(ICompanyRepository companyRepository) 
        {
            _companyRepository = companyRepository;

            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(3).WithMessage("{PropertyName} must not exceed 3 characters.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            //RuleFor(c => c.LogoUrl)
            //    .MaximumLength(200).WithMessage("Logo URL must not exceed 200 characters.")
            //    .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            //    .When(c => !string.IsNullOrEmpty(c.LogoUrl))
            //    .WithMessage("Logo URL must be a valid URL.");

            RuleFor(c => c)
                .MustAsync(CompanyCodeUnique)
                .WithMessage("A company with the same code already exists.");
        }

        private async Task<bool> CompanyCodeUnique(CreateCompanyCommand e, CancellationToken token)
        {
            return !await _companyRepository.IsCompanyCodeUnique(e.Code);
        }
    }
}
