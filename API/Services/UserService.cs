using API.Extensions;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IUserService
    {
        Task<AppUser> FindByEmailFromClaimsPrinciple(ClaimsPrincipal claimPrincipal);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> FindByEmailFromClaimsPrinciple(ClaimsPrincipal claimPrincipal) =>
            await _userManager.FindByEmailFromClaimsPrinciple(claimPrincipal);
    }
}
