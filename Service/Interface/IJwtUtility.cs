using Entities.Models;

namespace Service.Interface
{
    public interface IJwtUtility
    {
        public string CreateToken(User user);
    }
}
