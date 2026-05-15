using AutoMapper;
using PrintingCentre.Management.Application.Features.Companies.Commands.CreateCompany;
using PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompaniesList;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail;
using PrintingCentre.Management.Application.Features.Envelopes.Commands.CreateEnvelope;
using PrintingCentre.Management.Application.Features.Envelopes.Commands.UpdateEnvelope;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopesList;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopeDetail;
using PrintingCentre.Management.Application.Features.Flows.Commands.CreateFlow;
using PrintingCentre.Management.Application.Features.Flows.Commands.UpdateFlow;
using PrintingCentre.Management.Application.Features.Flows.Queries.Dtos;
using PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsList;
using PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowDetail;
using PrintingCentre.Management.Application.Features.FlowSequences.Commands.CreateFlowSequence;
using PrintingCentre.Management.Application.Features.FlowSequences.Commands.UpdateFlowSequence;
using PrintingCentre.Management.Application.Features.FlowSequences.Queries.GetFlowSequencesByFlow;
using PrintingCentre.Management.Application.Features.FlowSequences.Queries.GetFlowSequenceDetail;
using PrintingCentre.Management.Application.Features.PrintTemplates.Commands.CreatePrintTemplate;
using PrintingCentre.Management.Application.Features.PrintTemplates.Commands.UpdatePrintTemplate;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplateDetail;
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

            CreateMap<PrintTemplate, PrintTemplateListVm>().ReverseMap();
            CreateMap<PrintTemplate, PrintTemplateDetailVm>().ReverseMap();
            CreateMap<PrintTemplate, CreatePrintTemplateCommand>().ReverseMap();
            CreateMap<PrintTemplate, UpdatePrintTemplateCommand>().ReverseMap();

            CreateMap<Envelope, EnvelopeListVm>().ReverseMap();
            CreateMap<Envelope, EnvelopeDetailVm>().ReverseMap();
            CreateMap<Envelope, CreateEnvelopeCommand>().ReverseMap();
            CreateMap<Envelope, UpdateEnvelopeCommand>().ReverseMap();

            CreateMap<Flow, FlowListVm>().ReverseMap();
            CreateMap<FlowSequence, FlowSequenceDto>()
                .ForMember(dest => dest.Templates, opt => opt.MapFrom(src => src.FlowSequencePrintTemplates))
                .ForMember(dest => dest.Envelopes, opt => opt.MapFrom(src => src.FlowSequenceEnvelopes));
            CreateMap<FlowSequencePrintTemplate, PrintTemplateDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.PrintTemplate.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.PrintTemplate.Description));
            CreateMap<FlowSequenceEnvelope, EnvelopeDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Envelope.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Envelope.Description));

            CreateMap<Flow, FlowDetailVm>().ReverseMap();
            CreateMap<Flow, CreateFlowCommand>().ReverseMap();

            CreateMap<FlowSequence, CreateFlowSequenceData>()
                .ForMember(dest => dest.Templates, opt => opt.MapFrom(src => src.FlowSequencePrintTemplates))
                .ForMember(dest => dest.Envelopes, opt => opt.MapFrom(src => src.FlowSequenceEnvelopes));
            CreateMap<CreateFlowSequenceData, FlowSequence>()
                .ForMember(dest => dest.FlowSequencePrintTemplates, opt => opt.MapFrom(src => src.Templates))
                .ForMember(dest => dest.FlowSequenceEnvelopes, opt => opt.MapFrom(src => src.Envelopes));

            CreateMap<FlowSequencePrintTemplate, CreateFlowSequenceTemplateData>();
            CreateMap<CreateFlowSequenceTemplateData, FlowSequencePrintTemplate>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<FlowSequenceEnvelope, CreateFlowSequenceEnvelopeData>();
            CreateMap<CreateFlowSequenceEnvelopeData, FlowSequenceEnvelope>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<Flow, UpdateFlowCommand>().ReverseMap();

            CreateMap<UpdateFlowSequenceData, FlowSequence>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.FlowSequencePrintTemplates, opt => opt.MapFrom(src => src.Templates))
                .ForMember(dest => dest.FlowSequenceEnvelopes, opt => opt.MapFrom(src => src.Envelopes));
            CreateMap<UpdateFlowSequenceTemplateData, FlowSequencePrintTemplate>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
            CreateMap<UpdateFlowSequenceEnvelopeData, FlowSequenceEnvelope>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<FlowDetailVm, UpdateFlowCommand>()
                .ForMember(dest => dest.FlowSequences, opt => opt.MapFrom(src => src.FlowSequences));
            CreateMap<FlowSequenceDto, UpdateFlowSequenceData>()
                .ForMember(dest => dest.Templates, opt => opt.MapFrom(src => src.Templates))
                .ForMember(dest => dest.Envelopes, opt => opt.MapFrom(src => src.Envelopes));
            CreateMap<PrintTemplateDto, UpdateFlowSequenceTemplateData>();
            CreateMap<EnvelopeDto, UpdateFlowSequenceEnvelopeData>();

            CreateMap<FlowSequence, FlowSequenceListVm>().ReverseMap();
            CreateMap<FlowSequence, FlowSequenceDetailVm>().ReverseMap();
            CreateMap<FlowSequence, CreateFlowSequenceCommand>().ReverseMap();
            CreateMap<FlowSequence, UpdateFlowSequenceCommand>().ReverseMap();
        }
    }
}
