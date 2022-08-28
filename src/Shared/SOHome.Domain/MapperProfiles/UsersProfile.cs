using AutoMapper;

using SOHome.Common.DataModels;
using SOHome.Domain.Models;
using SOHome.Domain.Responses;

namespace SOHome.Domain.MapperProfiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<Person, RegisterModel>()
            .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
            .ForMember(dest => dest.Document, map => map.MapFrom(src => src.Document))
            .ReverseMap();

        CreateMap<OpenIdToken, UserDto>()
            .ForMember(dest => dest.RefreshToken, map => map.MapFrom(src => src.RefreshToken))
            .ForMember(dest => dest.Token, map => map.MapFrom(src => src.AccessToken));

        CreateMap<UserInfo, UserDto>()
            .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
            .ForMember(dest => dest.Username, map => map.MapFrom(src => src.PreferredUsername));
    }
}
