using MediatR;

namespace PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest
    {
        public Guid CompanyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
