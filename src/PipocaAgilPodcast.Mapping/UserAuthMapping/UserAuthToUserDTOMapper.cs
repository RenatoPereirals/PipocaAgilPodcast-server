using AutoMapper;
using PipocaAgilPodcast.Application.DTOs;
using PipocaAgilPodcast.Authentication.Identity;

namespace PipocaAgilPodcast.Mapping.UserMapping
{
    public class UserAuthToUserDTOMapper : Profile
    {
        public UserAuthToUserDTOMapper()
        {            
            CreateMap<UserAuth, UserLoginDto>().ReverseMap();
        }
    }
}