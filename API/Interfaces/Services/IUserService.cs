using Core.Entities.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Interfaces.Services
{
    public interface IUserService
    {
        Task<AppUser> FindByEmailFromClaimsPrinciple(ClaimsPrincipal claimPrincipal);
    }
}
