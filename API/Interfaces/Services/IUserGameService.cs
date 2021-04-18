using API.Data;
using API.Dtos.Entities;
using API.Helpers;
using Core.Entities.Identity;
using Core.Interfaces;
using System.Threading.Tasks;

namespace API.Interfaces.Services
{
    public interface IUserGameService
    {
        Task<bool> UserHasGame(AppUser user, int gameId);
        Task<ApiResponse<IPagination<GameDto>>> GetUserGames(AppUser user,PaginationParams pagination);
    }
}
