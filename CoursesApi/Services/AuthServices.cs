﻿using CoursesApi.Data.Repositories;
using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;
using CoursesApi.Models.Enums;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CoursesApi.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IAuthRepository authRepository;
        private readonly IConfiguration configuration;

        public AuthServices(IAuthRepository authRepository, IConfiguration configuration)
        {
            this.authRepository = authRepository;
            this.configuration = configuration;
        }

        public async Task<string> GetUserToken(UserLogInDto userInfo)
        {
            var userDomain = await authRepository.GetUserByEmail(userInfo.Email);
            if (userDomain == null) 
            {
                throw new Exception("User Not Found");
            }
            if (!VerifyPassword(userInfo.Password, userDomain.HashedPassword)) 
            {
                throw new Exception("Password Incorrect");
            }
            // generate token
            return $"key:{GenerateJwtToken(userDomain)}";
        }

        public async Task<User> SaveUser(UserRegisterDto userRegisterDto)
        {
            var hashedPassword = HashPassword(userRegisterDto.Password);
            if (!Enum.TryParse<UserType>(userRegisterDto.Role, true, out var role))
            {
                throw new Exception("Invalid User Type");
            }
            //todo use automapper
            var user = new User
            {
                FullName = userRegisterDto.FullName,
                Email = userRegisterDto.Email,
                HashedPassword = hashedPassword,
                Role = role
            };
            user = await authRepository.SaveAsync(user);
            return user;
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);

            return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHashBytes = Convert.FromBase64String(parts[1]);

            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32);

            return hash.SequenceEqual(storedHashBytes);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.Role, user.Role.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = configuration["Jwt:isu"],
                Audience = configuration["jwt:aud"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
