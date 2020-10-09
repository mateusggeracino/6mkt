using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Api.Models.Requests.Offers;
using _6MKT.BackOffice.Api.Models.Responses.Offers;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _6MKT.BackOffice.Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Add(OfferAddRequest offer)
        {
            var offerEntity = _mapper.Map<OfferEntity>(offer);
            await _offerService.Add(offerEntity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OfferUpdateRequest offer)
        {
            var offerEntity = _mapper.Map<OfferEntity>(offer);
            await _offerService.Update(offerEntity);
            return Ok();
        }

        [HttpDelete("{offerId:long}")]
        public async Task<IActionResult> Remove([FromRoute] long offerId)
        {
            await _offerService.Remove(offerId);
            return Ok();
        }

        //[HttpGet("{offerId:long}")]
        //public async Task<ActionResult<OfferResponse>> GetById([FromRoute] long offerId)
        //{
        //    var offerEntity = await _offerService.GetById(offerId);
        //    return Ok(_mapper.Map<OfferResponse>(offerEntity));
        //}
    }
}
