﻿using _6MKT.BackOffice.Api.Attributes;
using _6MKT.BackOffice.Api.Models.Requests.Purchases;
using _6MKT.BackOffice.Api.Models.Responses.Purchases;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;
using _6MKT.BackOffice.Domain.ValueObjects.Purchase;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _6MKT.BackOffice.Api.Controllers
{
    [ApiController]
    [Route("api/purchase")]
    public class PurchaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseService _purchaseService;
        private readonly IPurchaseCompletedService _purchaseCompletedService;

        public PurchaseController(IMapper mapper, IPurchaseService purchaseService, 
            IPurchaseCompletedService purchaseCompletedService)
        {
            _mapper = mapper;
            _purchaseService = purchaseService;
            _purchaseCompletedService = purchaseCompletedService;
        }

        [HttpPost]
        [AuthorizeProfile(UserTypesConstants.NaturalPerson)]
        public async Task<IActionResult> Add([FromBody] PurchaseAddRequest purchase)
        {
            var purchaseEntity = _mapper.Map<PurchaseEntity>(purchase);
            await _purchaseService.AddAsync(purchaseEntity);
            return Ok();
        }

        [HttpPut]
        [AuthorizeProfile(UserTypesConstants.NaturalPerson)]
        public async Task<IActionResult> Update([FromBody] PurchaseUpdateRequest purchase)
        {
            var purchaseEntity = _mapper.Map<PurchaseEntity>(purchase);
            await _purchaseService.UpdateAsync(purchaseEntity);
            return Ok();
        }

        [HttpDelete("{purchaseId:long}")]
        [AuthorizeProfile(UserTypesConstants.NaturalPerson)]
        public async Task<IActionResult> Remove([FromRoute] long purchaseId)
        {
            await _purchaseService.RemoveAsync(purchaseId);
            return Ok();
        }

        [HttpGet("{purchaseId:long}")]
        public async Task<ActionResult<PurchaseResponse>> GetById([FromRoute] long purchaseId)
        {
            var purchaseEntity = await _purchaseService.GetByIdAsync(purchaseId);
            return Ok(_mapper.Map<PurchaseResponse>(purchaseEntity));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<PageResponse<Purchases>>> GetAll([FromBody] PageRequest page)
        {
            var purchaseEntity = await _purchaseService.GetAllListAsync(page);
            return Ok(_mapper.Map<PageResponse<Purchases>>(purchaseEntity));
        }

        [HttpPost("{purchaseId:long}/acceptance/{offerId:long}")]
        public async Task<IActionResult> SelectOffer([FromRoute] long purchaseId, long offerId)
        {
            await _purchaseCompletedService.AddAsync(PurchaseCompletedEntity.New(purchaseId, offerId));
            return Ok();
        }
    }
}
