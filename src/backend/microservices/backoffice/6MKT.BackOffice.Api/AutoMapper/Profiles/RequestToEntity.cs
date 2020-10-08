using _6MKT.BackOffice.Api.Models.Requests.Business;
using _6MKT.BackOffice.Api.Models.Requests.NaturalPeople;
using _6MKT.BackOffice.Domain.Entities;
using AutoMapper;

namespace _6MKT.BackOffice.Api.AutoMapper.Profiles
{
    public class RequestToEntity : Profile
    {
        public RequestToEntity()
        {
            #region Natural Person
            CreateMap<NaturalPersonAddViewModel, NaturalPersonEntity>();
            CreateMap<NaturalPersonUpdateViewModel, NaturalPersonEntity>();
            #endregion

            #region Business
            CreateMap<BusinessAddViewModel, BusinessEntity>();
            CreateMap<BusinessUpdateViewModel, BusinessEntity>();
            #endregion
        }
    }
}