using AutoMapper;
using ContactManager.Infrastructure.Domain.Data;
using ContactManager.Infrastructure.Domain.DTO.Application;
using ContactManager.Infrastructure.Domain.DTO.Contact;
using System.Collections.Generic;

namespace ContactManager.API.ConfigurationMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ApplicationDTO, Applications>()
                .ForMember(dest => dest.Description, source => source.MapFrom(s => s.Description))
                .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
                .ForMember(dest => dest.Name, source => source.MapFrom(s => s.Name));

            CreateMap<ContactDTO, People>()
                .ForMember(dest => dest.Name, source => source.MapFrom(s => s.Name))
                .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
                .ForMember(dest => dest.Phone, source => source.MapFrom(s => s.Phone))
                .ForMember(dest => dest.Email, source => source.MapFrom(s => s.Email))
                .ForMember(dest => dest.Apps, source => source.MapFrom(s => Mapper.Map<IList<ApplicationDTO>, IList<Applications>>(s.Apps)));
                
            CreateMap<Applications, ApplicationDTO>()
                .ForMember(dest => dest.Description, source => source.MapFrom(s => s.Description))
                .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
                .ForMember(dest => dest.Name, source => source.MapFrom(s => s.Name));

            CreateMap<People, ContactDTO>()
                .ForMember(dest => dest.Name, source => source.MapFrom(s => s.Name))
                .ForMember(dest => dest.Id, source => source.MapFrom(s => s.Id))
                .ForMember(dest => dest.Phone, source => source.MapFrom(s => s.Phone))
                .ForMember(dest => dest.Email, source => source.MapFrom(s => s.Email))
                .ForMember(dest => dest.Applications,source => source.Ignore());
        }
    }
}