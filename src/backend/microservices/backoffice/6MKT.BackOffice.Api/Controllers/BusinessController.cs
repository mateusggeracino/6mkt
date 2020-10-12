using _6MKT.BackOffice.Api.Attributes;
using _6MKT.BackOffice.Api.Models.Requests.Business;
using _6MKT.BackOffice.Api.Models.Responses.Business;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Api.Controllers
{
    [ApiController]
    [Route("api/business")]
    public class BusinessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusinessService _businessService;

        public BusinessController(IMapper mapper, IBusinessService businessService)
        {
            _mapper = mapper;
            _businessService = businessService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BusinessAddRequest business)
        {
            var businessEntity = _mapper.Map<BusinessEntity>(business);
            await _businessService.AddAsync(businessEntity);
            return Ok();
        }

        [HttpPut]
        [AuthorizeProfile(UserTypesConstants.Business)]
        public async Task<IActionResult> Update([FromBody] BusinessUpdateRequest naturalPerson)
        {
            var businessEntity = _mapper.Map<BusinessEntity>(naturalPerson);
            await _businessService.UpdateAsync(businessEntity);
            return Ok();
        }

        [HttpDelete("{businessId:long}")]
        [AuthorizeProfile(UserTypesConstants.Business)]
        public async Task<IActionResult> Remove([FromRoute] long businessId)
        {
            await _businessService.RemoveAsync(businessId);
            return Ok();
        }

        [HttpGet("{businessId:long}")]
        [AuthorizeProfile(UserTypesConstants.Business, UserTypesConstants.NaturalPerson)]
        public async Task<ActionResult<BusinessResponse>> GetById([FromRoute] long businessId)
        {
            var business = await _businessService.GetByIdAsync(businessId);

            return Ok(_mapper.Map<BusinessResponse>(business));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<PageResponse<BusinessResponse>>> GetAll([FromBody] PageRequest page)
        {
            var business = await _businessService.GetAllAsync(page);
            return Ok(_mapper.Map<PageResponse<BusinessResponse>>(business));
        }
    }
}
