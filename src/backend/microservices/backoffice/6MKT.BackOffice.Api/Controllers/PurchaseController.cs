using _6MKT.BackOffice.Api.Models.Requests.Purchases;
using _6MKT.BackOffice.Api.Models.Responses.Purchases;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IMapper mapper, IPurchaseService purchaseService)
        {
            _mapper = mapper;
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PurchaseAddRequest purchase)
        {
            var purchaseEntity = _mapper.Map<PurchaseEntity>(purchase);
            await _purchaseService.Add(purchaseEntity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PurchaseUpdateRequest purchase)
        {
            var purchaseEntity = _mapper.Map<PurchaseEntity>(purchase);
            await _purchaseService.Update(purchaseEntity);
            return Ok();
        }

        [HttpDelete("{purchaseId:long}")]
        public async Task<IActionResult> Remove([FromRoute] long purchaseId)
        {
            await _purchaseService.Remove(purchaseId);
            return Ok();
        }

        [HttpGet("{purchaseId:long}")]
        public async Task<ActionResult<PurchaseResponse>> GetById([FromRoute] long purchaseId)
        {
            var purchaseEntity = await _purchaseService.GetById(purchaseId);
            return Ok(_mapper.Map<PurchaseResponse>(purchaseEntity));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<IEnumerable<PurchaseResponse>>> GetAll([FromBody] PageRequest page)
        {
            var purchaseEntity = await _purchaseService.GetAll(page);
            return Ok(_mapper.Map<IEnumerable<PurchaseResponse>>(purchaseEntity));
        }
    }
}
