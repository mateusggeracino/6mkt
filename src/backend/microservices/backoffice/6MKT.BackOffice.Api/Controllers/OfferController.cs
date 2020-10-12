using _6MKT.BackOffice.Api.Attributes;
using _6MKT.BackOffice.Api.Models.Requests.Offers;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Api.Controllers
{
    [Route("api/offer")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOfferService _offerService;

        public OfferController(IMapper mapper, IOfferService offerService)
        {
            _mapper = mapper;
            _offerService = offerService;
        }

        [HttpPost]
        [AuthorizeProfile(UserTypesConstants.Business)]
        public async Task<IActionResult> Add(OfferAddRequest offer)
        {
            var offerEntity = _mapper.Map<OfferEntity>(offer);
            await _offerService.AddAsync(offerEntity);
            return Ok();
        }

        [HttpPut]
        [AuthorizeProfile(UserTypesConstants.Business)]
        public async Task<IActionResult> Update([FromBody] OfferUpdateRequest offer)
        {
            var offerEntity = _mapper.Map<OfferEntity>(offer);
            await _offerService.UpdateAsync(offerEntity);
            return Ok();
        }

        [HttpDelete("{offerId:long}")]
        [AuthorizeProfile(UserTypesConstants.Business)]
        public async Task<IActionResult> Remove([FromRoute] long offerId)
        {
            await _offerService.RemoveAsync(offerId);
            return Ok();
        }

        //[HttpGet("{offerId:long}")]
        //public async Task<ActionResult<OfferResponse>> GetByIdAsync([FromRoute] long offerId)
        //{
        //    var offerEntity = await _offerService.GetByIdAsync(offerId);
        //    return Ok(_mapper.Map<OfferResponse>(offerEntity));
        //}
    }
}
