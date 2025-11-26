using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs.Skill;
using SkillTrack.API.Services.Interfaces;
using System.Security.Claims;


namespace SkillTrack.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // Extract logged-in user's Id from JWT
        private int GetUserIdFromToken()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
                throw new Exception("UserId not found in token");

            return int.Parse(claim.Value);
        }

        // GET: api/skills
        [HttpGet]
        public async Task<IActionResult> GetMySkills()
        {
            int userId = GetUserIdFromToken();
            var skills = await _skillService.GetSkillsByUserIdAsync(userId);
            return Ok(skills);
        }

        // POST: api/skills
        [HttpPost]
        public async Task<IActionResult> AddSkill([FromBody] SkillCreateDto dto)
        {
            int userId = GetUserIdFromToken();
            var result = await _skillService.AddSkillAsync(userId, dto);
            return Ok(result);
        }

        // PUT: api/skills/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody] SkillUpdateDto dto)
        {
            var result = await _skillService.UpdateSkillAsync(id, dto);
            return Ok(result);
        }

        // DELETE: api/skills/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            await _skillService.DeleteSkillAsync(id);
            return Ok("Skill deleted successfully");
        }
    }
}
