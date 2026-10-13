using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Activity;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivityController(TimeWastrDbContext _context) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ActivityDto>>> GetLoggedInUserActivities()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return NotFound();

            var activites = await _context.Activities.Where(a => a.UserId == userId).ToListAsync();

            return Ok(activites.Select((a) => a.ToActivityDto()));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ActivityDto>> GetById([FromRoute] int id)
        {
            var activity = await _context.Activities.FindAsync(id);

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

            await _context.Activities.AddAsync(activityModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = activityModel.Id },
                activityModel.ToActivityDto()
            );
        }
    }
}
