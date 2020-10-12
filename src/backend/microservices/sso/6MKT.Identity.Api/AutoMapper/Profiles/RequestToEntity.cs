using _6MKT.Identity.Api.Models.Request;
using _6MKT.Identity.Domain.Entities;
using AutoMapper;

namespace _6MKT.Identity.Api.AutoMapper.Profiles
{
    public class RequestToEntity : Profile
    {
        public RequestToEntity()
        {
            CreateMap<UserAddRequest, UserEntity>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(x => x.Password))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(x => true));

            CreateMap<UserLoginRequest, UserEntity>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(x => x.Password));
        }
    }
}