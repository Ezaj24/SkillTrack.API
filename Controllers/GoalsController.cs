using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs.Goal;
using SkillTrack.API.Services.Interfaces;
using System.Security.Claims;

namespace SkillTrack.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        // Get logged-in user's Id from JWT
        private int GetUserIdFromToken()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                throw new Exception("User Id not found in token");
            }

            return int.Parse(claim.Value);
        }

        // GET: api/goals
        [HttpGet]
        public async Task<IActionResult> GetMyGoals()
        {
            var userId = GetUserIdFromToken();
            var goals = await _goalService.GetGoalsByUserIdAsync(userId);
            return Ok(goals);
        }

        // POST: api/goals
        [HttpPost]
        public async Task<IActionResult> CreateGoal([FromBody] GoalCreateDto dto)
        {
            var userId = GetUserIdFromToken();
            var result = await _goalService.CreateGoalAsync(userId, dto);
            return Ok(result);
        }

        // PUT: api/goals/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] GoalUpdateDto dto)
        {
            var result = await _goalService.UpdateGoalAsync(id, dto);
            return Ok(result);
        }

        // PATCH: api/goals/{id}/complete
        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> MarkComplete(int id)
        {
            await _goalService.MarkGoalCompletedAsync(id);
            return Ok("Goal marked as completed");
        }

        // DELETE: api/goals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            await _goalService.DeleteGoalAsync(id);
            return Ok("Goal deleted successfully");
        }
    }
}
