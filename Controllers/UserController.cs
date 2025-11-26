using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrack.API.DTOs.User;
using SkillTrack.API.Services.Interfaces;
using System.Security.Claims;

namespace SkillTrack.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var result = await _userService.GetProfileAsync(GetUserId());
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile(UserUpdateDto dto)
        {
            var result = await _userService.UpdateProfileAsync(GetUserId(), dto);
            return Ok(result);
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            await _userService.ChangePasswordAsync(GetUserId(), dto);
            return Ok(new { message = "Password changed successfully" });
        }
    }
}
