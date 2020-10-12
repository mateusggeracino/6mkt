using _6MKT.BackOffice.Api.Models.Requests.Categories;
using _6MKT.BackOffice.Api.Models.Responses.Categories;
using _6MKT.BackOffice.Domain.Entities;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using _6MKT.BackOffice.Api.Attributes;
using _6MKT.BackOffice.Domain.Constants;
using _6MKT.BackOffice.Domain.ValueObjects.Pagination;

namespace _6MKT.BackOffice.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }


        [HttpPost]
        [AuthorizeProfile(UserTypesConstants.Admin)]
        public async Task<IActionResult> Add([FromBody] CategoryAddRequest category)
        {
            var businessEntity = _mapper.Map<CategoryEntity>(category);
            await _categoryService.AddAsync(businessEntity);
            return Ok();
        }

        [HttpPut]
        [AuthorizeProfile(UserTypesConstants.Admin)]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateRequest category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);
            await _categoryService.UpdateAsync(categoryEntity);
            return Ok();
        }

        [HttpDelete("{categoryId:long}")]
        [AuthorizeProfile(UserTypesConstants.Admin)]
        public async Task<IActionResult> Remove([FromRoute] long categoryId)
        {
            await _categoryService.RemoveAsync(categoryId);
            return Ok();
        }

        [HttpGet("{categoryId:long}")]
        public async Task<ActionResult<CategoryResponse>> GetById([FromRoute] long categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);

            return Ok(_mapper.Map<CategoryResponse>(category));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<PageResponse<CategoryResponse>>> GetAll(PageRequest page)
        {
            var categories = await _categoryService.GetAllAsync(page);
            return Ok(_mapper.Map<PageResponse<CategoryResponse>>(categories));
        }
    }
}
