using _6MKT.BackOffice.Api.Models.Responses.Business;
using _6MKT.BackOffice.Api.Models.Responses.NaturalPeople;
using _6MKT.BackOffice.Domain.Entities;
using AutoMapper;

namespace _6MKT.BackOffice.Api.AutoMapper.Profiles
{
    public class EntityToResponse : Profile
    {
        public EntityToResponse()
        {
            CreateMap<NaturalPersonEntity, NaturalPersonResponseViewModel>();
            CreateMap<BusinessEntity, BusinessResponseViewModel>();
        }
    }
}