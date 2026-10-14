using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Ingredient;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngredientController(IIngredientService _ingredientService) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<IngredientDto>>> GetLoggedInUserIngredients()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return NotFound();

            var activites = await _ingredientService.GetAllFromUserIdAsync(userId);

            return Ok(activites.Select((a) => a.ToIngredientDto()));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IngredientDto>> GetById([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return NotFound();

            var ingredient = await _ingredientService.GetByIdAsync(id, userId);

            if (ingredient == null)
                return NotFound();

            return Ok(ingredient.ToIngredientDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Create(
            [FromBody] CreateIngredientDto ingredientDto
        )
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var ingredient = ingredientDto.ToIngredientFromCreateDto(userId);

            await _ingredientService.CreateAsync(ingredient);

            return CreatedAtAction(
                nameof(GetById),
                new { id = ingredient.Id },
                ingredient.ToIngredientDto()
            );
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Update(
            [FromRoute] int id,
            [FromBody] CreateIngredientDto ingredientDto
        )
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var ingredient = await _ingredientService.UpdateAsync(id, userId, ingredientDto);

            if (ingredient == null)
                return BadRequest();

            return Ok(ingredient.ToIngredientDto());
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var ingredient = await _ingredientService.DeleteAsync(id, userId);

            if (ingredient == null)
                return BadRequest();

            return Ok();
        }
    }
}
