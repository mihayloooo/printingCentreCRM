using AutoMapper;
using PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail;
using PrintingCentre.Management.Application.Features.Envelopes.Commands.UpdateEnvelope;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopeDetail;
using PrintingCentre.Management.Application.Features.PrintTemplates.Commands.UpdatePrintTemplate;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplateDetail;

namespace PrintingCentre.Management.WebApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<CompanyDetailVm, UpdateCompanyCommand>().ReverseMap();
            CreateMap<PrintTemplateDetailVm, UpdatePrintTemplateCommand>().ReverseMap();
            CreateMap<EnvelopeDetailVm, UpdateEnvelopeCommand>().ReverseMap();
        }
    }
}
