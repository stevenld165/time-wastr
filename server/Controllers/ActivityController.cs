using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Activity;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivityController(IActivityService _activityService) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ActivityDto>>> GetLoggedInUserActivities()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return NotFound();

            var activites = await _activityService.GetAllFromUserIdAsync(userId);

            return Ok(activites.Select((a) => a.ToActivityDto()));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ActivityDto>> GetById([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var activity = await _activityService.GetByIdAsync(id, userId);

            if (activity == null)
                return NotFound();

            return Ok(activity.ToActivityDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Activity>> Create([FromBody] CreateActivityDto activityDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var activityModel = activityDto.ToActivityFromCreateDto(userId);

            await _activityService.CreateAsync(activityModel);

            return CreatedAtAction(
                nameof(GetById),
                new { id = activityModel.Id },
                activityModel.ToActivityDto()
            );
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Activity>> Update(
            [FromRoute] int id,
            [FromBody] CreateActivityDto activityDto
        )
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var activity = await _activityService.UpdateAsync(id, userId, activityDto);

            if (activity == null)
                return BadRequest();

            return Ok(activity.ToActivityDto());
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var activity = await _activityService.DeleteAsync(id, userId);

            if (activity == null)
                return BadRequest();

            return Ok();
        }
    }
}
