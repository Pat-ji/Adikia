using API.Data;
using API.Dtos.Entities;
using API.Helpers;
using API.Interfaces.Services;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Specifications;
using Infrastructure.Data;
using System.Net;
using System.Threading.Tasks;

namespace API.Services
{
    public class GameService : IGameService
    {
        private readonly IBaseRepository<Game> _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IBaseRepository<Game> gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IPagination<GameDto>>> GetGames(PaginationParams pagination)
        {
            var games = await _gameRepository.GetAllWithSpecAsync(new GameSpecification.Pagination(pagination.PageIndex, pagination.PageSize));

            return new ApiResponse<IPagination<GameDto>>((int) HttpStatusCode.OK, games.Mapped(x => _mapper.Map<GameDto>(x)));
        }
    }
}
