using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>();

            CreateMap<Message, MessageDto>()
            .ForMember(dest => dest.SenderUsername, opt => opt.MapFrom(src => src.Sender.Username));
        }
    }
}
