using _6MKT.BackOffice.Api.Attributes;
using _6MKT.BackOffice.Api.Models.Requests.SubCategories;
using _6MKT.BackOffice.Api.Models.Responses.SubCategories;
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
    [Route("api/subcategory")]
    public class SubCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(IMapper mapper, ISubCategoryService subCategoryService)
        {
            _mapper = mapper;
            _subCategoryService = subCategoryService;
        }

        [HttpPost]
        [AuthorizeProfile(UserTypesConstants.Admin)]
        public async Task<IActionResult> Add([FromBody] SubCategoryAddRequest subCategory)
        {
            var subCategoryEntity = _mapper.Map<SubCategoryEntity>(subCategory);
            await _subCategoryService.AddAsync(subCategoryEntity);
            return Ok();
        }

        [HttpPut]
        [AuthorizeProfile(UserTypesConstants.Admin)]
        public async Task<IActionResult> Update([FromBody] SubCategoryUpdateRequest subCategory)
        {
            var subCategoryEntity = _mapper.Map<SubCategoryEntity>(subCategory);
            await _subCategoryService.UpdateAsync(subCategoryEntity);
            return Ok();
        }

        [HttpDelete("{subCategoryId:long}")]
        [AuthorizeProfile(UserTypesConstants.Admin)]
        public async Task<IActionResult> Remove([FromRoute] long subCategoryId)
        {
            await _subCategoryService.RemoveAsync(subCategoryId);
            return Ok();
        }

        [HttpGet("{subCategoryId:long}")]
        public async Task<ActionResult<SubCategoryResponse>> GetById([FromRoute] long subCategoryId)
        {
            var subCategory = await _subCategoryService.GetByIdAsync(subCategoryId);

            return Ok(_mapper.Map<SubCategoryResponse>(subCategory));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<PageResponse<SubCategoryResponse>>> GetAll([FromBody] PageRequest page)
        {
            var subCategories = await _subCategoryService.GetAllAsync(page);
            return Ok(_mapper.Map<PageResponse<SubCategoryResponse>>(subCategories));
        }
    }
}
