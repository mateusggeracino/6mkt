using _6MKT.BackOffice.Api.Models.Requests;
using _6MKT.BackOffice.Domain.Entities;
using AutoMapper;

namespace _6MKT.BackOffice.Api.AutoMapper.Profiles
{
    public class EntityToResponse : Profile
    {
        public EntityToResponse()
        {
            CreateMap<ProviderEntity, ProviderAddViewModel>();
        }
    }
}