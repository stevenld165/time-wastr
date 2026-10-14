using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Category;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CategoryDto>>> GetLoggedInUserCategories()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return NotFound();

            var categories = await _categoryService.GetAllFromUserIdAsync(userId);

            return Ok(categories.Select((a) => a.ToCategoryDto()));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CategoryDto>> GetById([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return NotFound();

            var category = await _categoryService.GetByIdAsync(id, userId);

            if (category == null)
                return NotFound();

            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Category>> Create([FromBody] CreateCategoryDto categoryDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var category = categoryDto.ToCategoryFromCreateDto(userId);

            await _categoryService.CreateAsync(category);

            return CreatedAtAction(
                nameof(GetById),
                new { id = category.Id },
                category.ToCategoryDto()
            );
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Category>> Update(
            [FromRoute] int id,
            [FromBody] CreateCategoryDto categoryDto
        )
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var category = await _categoryService.UpdateAsync(id, userId, categoryDto);

            if (category == null)
                return BadRequest();

            return Ok(category.ToCategoryDto());
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var category = await _categoryService.DeleteAsync(id, userId);

            if (category == null)
                return BadRequest();

            return Ok();
        }
    }
}
