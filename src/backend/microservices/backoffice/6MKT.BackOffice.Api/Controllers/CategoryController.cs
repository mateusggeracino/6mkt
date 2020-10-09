using _6MKT.BackOffice.Api.Models.Requests.Categories;
using _6MKT.BackOffice.Api.Models.Responses.Categories;
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
        public async Task<IActionResult> Add([FromBody] CategoryAddRequest category)
        {
            var businessEntity = _mapper.Map<CategoryEntity>(category);
            await _categoryService.Add(businessEntity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateRequest category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);
            await _categoryService.Update(categoryEntity);
            return Ok();
        }

        [HttpDelete("{categoryId:long}")]
        public async Task<IActionResult> Remove([FromRoute] long categoryId)
        {
            await _categoryService.Remove(categoryId);
            return Ok();
        }

        [HttpGet("{categoryId:long}")]
        public async Task<ActionResult<CategoryResponse>> GetById([FromRoute] long categoryId)
        {
            var category = await _categoryService.GetById(categoryId);

            return Ok(_mapper.Map<CategoryResponse>(category));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CategoryResponse>>(categories));
        }
    }
}
