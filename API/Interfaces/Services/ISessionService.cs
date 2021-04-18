using API.Data;
using API.Dtos.Entities;
using API.Helpers;
using Core.Entities.Identity;
using Core.Interfaces;
using System.Threading.Tasks;

namespace API.Interfaces.Services
{
    public interface ISessionService
    {
        public Task<ApiResponse<SessionDto>> CreateSession(AppUser user, int gameId);
        public Task<ApiResponse<IPagination<SessionDto>>> GetSessions(AppUser user, PaginationParams pagination);
    }
}
