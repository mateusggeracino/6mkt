using System.Linq;
using _6MKT.BackOffice.Api.Models.Requests.Address;
using _6MKT.BackOffice.Api.Models.Requests.Business;
using _6MKT.BackOffice.Api.Models.Requests.Categories;
using _6MKT.BackOffice.Api.Models.Requests.NaturalPeople;
using _6MKT.BackOffice.Api.Models.Requests.Offers;
using _6MKT.BackOffice.Api.Models.Requests.Purchases;
using _6MKT.BackOffice.Api.Models.Requests.SubCategories;
using _6MKT.BackOffice.Domain.Entities;
using AutoMapper;

namespace _6MKT.BackOffice.Api.AutoMapper.Profiles
{
    public class RequestToEntity : Profile
    {
        public RequestToEntity()
        {
            #region Natural Person
            CreateMap<NaturalPersonAddRequest, NaturalPersonEntity>();
            CreateMap<NaturalPersonUpdateRequest, NaturalPersonEntity>();
            #endregion

            #region Business
            CreateMap<BusinessAddRequest, BusinessEntity>()
                .ForMember(dest => dest.SubCategories, opt => opt
                    .MapFrom(x => x.Subcategories.Select(s => new BusinessSubCategory { SubCategoryId = s })));

            CreateMap<BusinessUpdateRequest, BusinessEntity>()
                .ForMember(dest => dest.SubCategories, opt => opt
                    .MapFrom(x => x.Subcategories.Select(s => new BusinessSubCategory { SubCategoryId = s })));

            #endregion

            #region Category
            CreateMap<CategoryAddRequest, CategoryEntity>();
            CreateMap<CategoryUpdateRequest, CategoryEntity>();
            #endregion

            #region SubCategory
            CreateMap<SubCategoryAddRequest, SubCategoryEntity>();
            CreateMap<SubCategoryUpdateRequest, SubCategoryEntity>();
            #endregion

            #region Offer
            CreateMap<OfferAddRequest, OfferEntity>();
            CreateMap<OfferUpdateRequest, OfferEntity>();
            #endregion

            #region Purchase
            CreateMap<PurchaseAddRequest, PurchaseEntity>();
            CreateMap<PurchaseUpdateRequest, PurchaseEntity>();
            #endregion

            #region Address
            CreateMap<AddressAddRequest, AddressEntity>();
            CreateMap<AddressUpdateRequest, AddressEntity>();
            #endregion
        }
    }
}