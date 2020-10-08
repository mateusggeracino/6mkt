using _6MKT.BackOffice.Api.Models.Requests.Business;
using _6MKT.BackOffice.Api.Models.Responses.Business;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Add([FromBody] BusinessAddViewModel business)
        {
            var businessEntity = _mapper.Map<BusinessEntity>(business);
            await _businessService.Add(businessEntity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BusinessUpdateViewModel naturalPerson)
        {
            var businessEntity = _mapper.Map<BusinessEntity>(naturalPerson);
            await _businessService.Update(businessEntity);
            return Ok();
        }

        [HttpDelete("{businessId:long}")]
        public async Task<IActionResult> Remove([FromQuery] long businessId)
        {
            await _businessService.Remove(businessId);
            return Ok();
        }

        [HttpGet("{businessId:long}")]
        public async Task<ActionResult<BusinessResponseViewModel>> GetById([FromQuery] long businessId)
        {
            var business = await _businessService.GetById(businessId);

            return Ok(_mapper.Map<BusinessResponseViewModel>(business));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<BusinessResponseViewModel>>> GetAll()
        {
            var business = await _businessService.GetAll();
            return Ok(_mapper.Map<IEnumerable<BusinessResponseViewModel>>(business));
        }
    }
}
