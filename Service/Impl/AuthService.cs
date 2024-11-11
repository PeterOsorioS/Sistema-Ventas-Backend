using Data.Repository.Interface;
using Entities.Models;
using Service.Interface;
using Microsoft.AspNetCore.Identity;
using Service.DTOs;
using Exceptions;

namespace Service.Impl
{

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _password;
        private readonly IJwtUtility _token;

        public AuthService(IUserRepository userRepository,
            IPasswordHasher<User> password,
            IJwtUtility token)
        {
            _userRepository = userRepository;
            _password = password;
            _token = token;
        }
        public string Authentication(LoginDTO login)
        {
            var userExist = _userRepository.GetByEmail(login.Email);

            if (userExist == null ||
               _password.VerifyHashedPassword(userExist, userExist.Password, login.Password) != PasswordVerificationResult.Success)
            {
                throw new UnauthorizedAccessException("El correo electronico o contraseña es incorrecto.");
            }
            return _token.CreateToken(userExist);
        }

        public string Register(RegisterDTO register)
        {
            var userExist = _userRepository.GetByEmail(register.Email);
            if (userExist != null)
            {
                throw new BadRequestException("Ya existe un usuario con ese correo.");
            }
            _userRepository.Add(userExist);

            var token = _token.CreateToken(userExist);
            return token;
        }

    }
}