using API.Dtos.Entities;
using API.Errors;
using API.Helpers;
using API.Interfaces.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;
        private readonly IUserService _userService;
        private readonly IUserGameService _userGameService;

        public GameController(IGameService gameService, IUserService userService, IUserGameService userGameService)
        {
            _gameService = gameService;
            _userService = userService;
            _userGameService = userGameService;
        }

        [HttpGet("overview")]
        public async Task<ActionResult<Pagination<GameDto>>> GetGames([FromQuery] PaginationParams pagination)
        {
            var result = await _gameService.GetGames(pagination);
            return Resolve(result);
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<ActionResult<Pagination<GameDto>>> GetUserGames([FromQuery] PaginationParams pagination)
        {
            var user = await _userService.FindByEmailFromClaimsPrinciple(HttpContext.User);
            if (user == null) return Unauthorized(new ApiException((int)HttpStatusCode.Unauthorized));

            var result = await _userGameService.GetUserGames(user, pagination);
            return Resolve(result);
        }
    }
}
