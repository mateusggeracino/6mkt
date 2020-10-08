using _6MKT.BackOffice.Api.Models.Requests.NaturalPeople;
using _6MKT.BackOffice.Api.Models.Responses.NaturalPeople;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NaturalPersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INaturalPersonService _naturalPersonService;

        public NaturalPersonController(IMapper mapper, INaturalPersonService naturalPersonService)
        {
            _mapper = mapper;
            _naturalPersonService = naturalPersonService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NaturalPersonAddViewModel naturalPerson)
        {
            var naturalPersonEntity = _mapper.Map<NaturalPersonEntity>(naturalPerson);
            await _naturalPersonService.Add(naturalPersonEntity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NaturalPersonUpdateViewModel naturalPerson)
        {
            var naturalPersonEntity = _mapper.Map<NaturalPersonEntity>(naturalPerson);
            await _naturalPersonService.Update(naturalPersonEntity);
            return Ok();
        }

        [HttpDelete("{naturalPersonId:long}")]
        public async Task<IActionResult> Remove([FromQuery] long naturalPersonId)
        {
            await _naturalPersonService.Remove(naturalPersonId);
            return Ok();
        }

        [HttpGet("{naturalPersonId:long}")]
        public async Task<ActionResult<NaturalPersonResponseViewModel>> GetById([FromQuery] long naturalPersonId)
        {
            var naturalPerson = await _naturalPersonService.GetById(naturalPersonId);

            return Ok(_mapper.Map<NaturalPersonResponseViewModel>(naturalPerson));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<NaturalPersonResponseViewModel>>> GetAll()
        {
            var naturalPeople = await _naturalPersonService.GetAll();
            return Ok(_mapper.Map<IEnumerable<NaturalPersonResponseViewModel>>(naturalPeople));
        }
    }
}