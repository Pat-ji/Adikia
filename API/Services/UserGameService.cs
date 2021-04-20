using API.Data;
using API.Dtos.Entities;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Specifications;
using Infrastructure.Data;
using System.Net;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IUserGameService
    {
        Task<bool> UserHasGame(AppUser user, int gameId);
        Task<ApiResponse<IPagination<GameDto>>> GetUserGames(AppUser user, PaginationParams pagination);
    }

    public class UserGameService : IUserGameService
    {
        private readonly IBaseRepository<UserGame> _userGameRepository;
        private readonly IMapper _mapper;

        public UserGameService(IBaseRepository<UserGame> userGameRepository, IMapper mapper)
        {
            _userGameRepository = userGameRepository;
            _mapper = mapper;
        }

        public async Task<bool> UserHasGame(AppUser user, int gameId)
        {
            var spec = new UserGameSpecification.UserHasGame(user, gameId);

            return await _userGameRepository.AnyWithSpecAsync(spec);
        }

        public async Task<ApiResponse<IPagination<GameDto>>> GetUserGames(AppUser user, PaginationParams pagination)
        {
            var userGames = await _userGameRepository.GetAllWithSpecAsync(new UserGameSpecification.Pagination(user, pagination.PageIndex, pagination.PageSize));

            return new ApiResponse<IPagination<GameDto>>((int)HttpStatusCode.OK, userGames.Mapped(x => _mapper.Map<GameDto>(x.Game)));
        }
    }
}
