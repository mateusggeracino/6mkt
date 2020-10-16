using _6MKT.BackOffice.Api.Models.Requests.NaturalPeople;
using _6MKT.BackOffice.Api.Models.Responses.NaturalPeople;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Api.Attributes;
using _6MKT.BackOffice.Api.Models.Responses.Purchases;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.Purchase;

namespace _6MKT.BackOffice.Api.Controllers
{
    [ApiController]
    [Route("api/naturalperson")]
    public class NaturalPersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INaturalPersonService _naturalPersonService;
        private readonly IPurchaseService _purchaseService;

        public NaturalPersonController(IMapper mapper, INaturalPersonService naturalPersonService, IPurchaseService purchaseService)
        {
            _mapper = mapper;
            _naturalPersonService = naturalPersonService;
            _purchaseService = purchaseService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NaturalPersonAddRequest naturalPerson)
        {
            var naturalPersonEntity = _mapper.Map<NaturalPersonEntity>(naturalPerson);
            await _naturalPersonService.AddAsync(naturalPersonEntity);
            return Ok();
        }

        [HttpPut]
        [AuthorizeProfile(UserTypesConstants.NaturalPerson)]
        public async Task<IActionResult> Update([FromBody] NaturalPersonUpdateRequest naturalPerson)
        {
            var naturalPersonEntity = _mapper.Map<NaturalPersonEntity>(naturalPerson);
            await _naturalPersonService.UpdateAsync(naturalPersonEntity);
            return Ok();
        }

        [HttpDelete("{naturalPersonId:long}")]
        [AuthorizeProfile(UserTypesConstants.NaturalPerson)]
        public async Task<IActionResult> Remove([FromRoute] long naturalPersonId)
        {
            await _naturalPersonService.RemoveAsync(naturalPersonId);
            return Ok();
        }

        [HttpGet("{naturalPersonId:long}")]
        public async Task<ActionResult<NaturalPersonResponse>> GetById([FromRoute] long naturalPersonId)
        {
            var naturalPerson = await _naturalPersonService.GetByIdAsync(naturalPersonId);

            return Ok(_mapper.Map<NaturalPersonResponse>(naturalPerson));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<PageResponse<NaturalPersonResponse>>> GetAll([FromBody] PageRequest page)
        {
            var naturalPeople = await _naturalPersonService.GetAllAsync(page);
            return Ok(_mapper.Map<PageResponse<NaturalPersonResponse>>(naturalPeople));
        }

        [HttpPost("get-all-purchase")]
        [AuthorizeProfile(UserTypesConstants.NaturalPerson)]
        public async Task<ActionResult<PageResponse<Purchases>>> GetAllPurchase([FromBody] PageRequest page)
        {
            var purchases = await _purchaseService.GetAllByNaturalPersonAsync(page);
            return Ok(_mapper.Map<PageResponse<Purchases>>(purchases));
        }
    }
}