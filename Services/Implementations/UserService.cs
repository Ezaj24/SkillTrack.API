using SkillTrack.API.DTOs.User;
using SkillTrack.API.Repositories.Interfaces;
using SkillTrack.API.Services.Interfaces;
using SkillTrack.API.Models;
using System.Security.Cryptography;
using System.Text;

namespace SkillTrack.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserProfileDto> GetProfileAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
                throw new Exception("User not found");

            return new UserProfileDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public async Task<UserProfileDto> UpdateProfileAsync(int userId, UserUpdateDto dto)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
                throw new Exception("User not found");

            user.UserName = dto.UserName;
            user.Email = dto.Email;

            await _userRepository.SaveChangesAsync();

            return new UserProfileDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto dto)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            // Verify old password
            if (!VerifyPassword(dto.CurrentPassword, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Current password is incorrect");

            // Create new hash + salt
            CreatePasswordHash(dto.NewPassword, out byte[] newHash, out byte[] newSalt);

            user.PasswordHash = newHash;
            user.PasswordSalt = newSalt;

            await _userRepository.SaveChangesAsync();
            return true;
        }

        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }

        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
