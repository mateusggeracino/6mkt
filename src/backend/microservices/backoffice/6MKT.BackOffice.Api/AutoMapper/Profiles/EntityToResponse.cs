using System.Linq;
using _6MKT.BackOffice.Api.Models.Responses.Address;
using _6MKT.BackOffice.Api.Models.Responses.Business;
using _6MKT.BackOffice.Api.Models.Responses.Categories;
using _6MKT.BackOffice.Api.Models.Responses.NaturalPeople;
using _6MKT.BackOffice.Api.Models.Responses.Offers;
using _6MKT.BackOffice.Api.Models.Responses.Purchases;
using _6MKT.BackOffice.Api.Models.Responses.SubCategories;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using AutoMapper;

namespace _6MKT.BackOffice.Api.AutoMapper.Profiles
{
    public class EntityToResponse : Profile
    {
        public EntityToResponse()
        {
            CreateMap<NaturalPersonEntity, NaturalPersonResponse>();

            CreateMap<BusinessEntity, BusinessResponse>()
                .ForMember(x => x.SubCategories, opt => opt
                    .MapFrom(x => x.SubCategories.Select(s => s.SubCategory)));

            CreateMap<CategoryEntity, CategoryResponse>();
            CreateMap<SubCategoryEntity, SubCategoryResponse>();
            CreateMap<OfferEntity, OfferResponse>();
            CreateMap<PurchaseEntity, PurchaseResponse>();
            CreateMap<AddressEntity, AddressResponse>();

            CreateMap(typeof(PageResponse<>), typeof(PageResponse<>));
        }
    }
}