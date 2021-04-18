using API.Data;
using API.Dtos.Entities;
using API.Helpers;
using Core.Interfaces;
using System.Threading.Tasks;

namespace API.Interfaces.Services
{
    public interface IGameService
    {
        public Task<ApiResponse<IPagination<GameDto>>> GetGames(PaginationParams pagination);
    }
}
