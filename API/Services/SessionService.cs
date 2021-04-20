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
using System;
using System.Net;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ISessionService
    {
        public Task<ApiResponse<SessionDto>> CreateSession(AppUser user, int gameId);
        public Task<ApiResponse<IPagination<SessionDto>>> GetSessions(AppUser user, PaginationParams pagination);
    }

    public class SessionService : ISessionService
    {
        private readonly IUserGameService _userGameService;
        private readonly ISessionCharacterService _sessionCharacterService;
        private readonly IBaseRepository<Session> _sessionRepository;
        private readonly IMapper _mapper;

        public SessionService(IUserGameService userGameService, ISessionCharacterService sessionCharacterService, IBaseRepository<Session> sessionRepository, IMapper mapper)
        {
            _userGameService = userGameService;
            _sessionCharacterService = sessionCharacterService;
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<SessionDto>> CreateSession(AppUser user, int gameId)
        {
            // Validate if user has access to the game
            var access = await _userGameService.UserHasGame(user, gameId);
            if (!access) return new ApiResponse<SessionDto>((int) HttpStatusCode.Unauthorized);

            // Create the session
            var session = new Session
            {
                AppUserId = user.Id,
                GameId = gameId,
                StartDate = DateTime.Now
            };

            var result = await _sessionRepository.AddAsync(session, true);

            // Create session dependencies
            await _sessionCharacterService.CreateSessionCharacters(session);

            return new ApiResponse<SessionDto>((int)HttpStatusCode.OK, _mapper.Map<SessionDto>(result));
        }

        public async Task<ApiResponse<IPagination<SessionDto>>> GetSessions(AppUser user, PaginationParams pagination)
        {
            var sessions = await _sessionRepository.GetAllWithSpecAsync(new SessionSpecification.Pagination(user, pagination.PageIndex, pagination.PageSize));

            return new ApiResponse<IPagination<SessionDto>>((int)HttpStatusCode.OK, sessions.Mapped(x => _mapper.Map<SessionDto>(x)));
        }
    }
}
