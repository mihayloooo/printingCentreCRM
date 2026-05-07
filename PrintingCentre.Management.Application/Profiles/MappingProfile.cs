using AutoMapper;
using PrintingCentre.Management.Application.Features.Companies.Commands.CreateCompany;
using PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompaniesList;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Company, CompanyListVm>().ReverseMap();
            CreateMap<Company, CompanyDetailVm>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
        }
    }
}
