using Core.Entities.Identity;

namespace API.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}