using Service.DTOs;

namespace Service.Interface
{
    public interface IAuthService
    {
        public string Register(RegisterDTO register);
        public string Authentication(LoginDTO login);
    }
}
