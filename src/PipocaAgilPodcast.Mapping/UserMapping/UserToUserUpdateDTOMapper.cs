using AutoMapper;
using PipocaAgilPodcast.Application.DTOs;
using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Mapping.UserMapping
{
    public class UserToUserUpdateDTOMapper : Profile
    {
        public UserToUserUpdateDTOMapper()
        {
            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}