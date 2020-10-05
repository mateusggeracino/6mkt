using _6MKT.BackOffice.Api.Models.Requests;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProviderController(IProviderService providerService, IMapper mapper)
        {
            _providerService = providerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Add([FromBody] ProviderAddViewModel provider)
        {
            var providerEntity = _mapper.Map<ProviderEntity>(provider);
            await _providerService.Add(providerEntity);
            return Ok();
        }
    }
}
