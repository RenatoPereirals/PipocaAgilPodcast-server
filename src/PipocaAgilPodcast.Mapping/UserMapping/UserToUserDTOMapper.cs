using AutoMapper;
using PipocaAgilPodcast.Application.DTOs;
using PipocaAgilPodcast.Authentication.Identity;
using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Mapping.UserMapping
{
    public class UserToUserDTOMapper : Profile
    {
        public UserToUserDTOMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();

            CreateMap<UserAuth, UserLoginDto>().ReverseMap();
            CreateMap<UserDTO, UserAuth>().ReverseMap();
            CreateMap<UserUpdateDTO, UserAuth>().ReverseMap();  
        }
    }
}