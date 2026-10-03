using InspectionCenter.Application.ServiceDtos.AuthDtos;
using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Domain.Entities;
using InspectionCenter.Domain.Enums;
using InspectionCenter.Repositories.RepositoryInterface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.MainServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IUserRepository userRepository
            , ITokenService tokenService
            , IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task Register(RegisterDto dto)
        {
            if (await _userRepository.ExistUserByEmailAsync(dto.Email))
                throw new InvalidOperationException("This Email Already Exists !!");

            var user = new User();

            user.SetFirstName(dto.FirstName);
            user.SetLastName(dto.LastName);
            user.SetAge(dto.Age);
            user.SetEmail(dto.Email);
            user.SetPassword(_passwordHasher.HashPassword(user, dto.Password));

            await _userRepository.AddAsync(user);
        }

        public async Task<AuthResponseDto> Login(LoginDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email);
            if (user is null &&
                _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password)
                == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Username/Password is invalid !");

            var (token, expires) = _tokenService.CreateToken(user);
            return new AuthResponseDto { Token = token, ExpiresAt = expires, Role = user.UserRole };
        }
    }
}
