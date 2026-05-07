namespace PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail
{
    public class CompanyDetailVm
    {
        public Guid CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }

    }
}