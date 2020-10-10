using _6MKT.BackOffice.Api.Models.Responses.SubCategories;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Api.Models.Requests.SubCategories;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Add([FromBody] SubCategoryAddRequest subCategory)
        {
            var subCategoryEntity = _mapper.Map<SubCategoryEntity>(subCategory);
            await _subCategoryService.Add(subCategoryEntity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SubCategoryUpdateRequest subCategory)
        {
            var subCategoryEntity = _mapper.Map<SubCategoryEntity>(subCategory);
            await _subCategoryService.Update(subCategoryEntity);
            return Ok();
        }

        [HttpDelete("{subCategoryId:long}")]
        public async Task<IActionResult> Remove([FromRoute] long subCategoryId)
        {
            await _subCategoryService.Remove(subCategoryId);
            return Ok();
        }

        [HttpGet("{subCategoryId:long}")]
        public async Task<ActionResult<SubCategoryResponse>> GetById([FromRoute] long subCategoryId)
        {
            var subCategory = await _subCategoryService.GetById(subCategoryId);

            return Ok(_mapper.Map<SubCategoryResponse>(subCategory));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<IEnumerable<SubCategoryResponse>>> GetAll([FromBody] PageRequest page)
        {
            var subCategories = await _subCategoryService.GetAll(page);
            return Ok(_mapper.Map<IEnumerable<SubCategoryResponse>>(subCategories));
        }
    }
}
