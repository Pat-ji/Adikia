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
    public class SessionController : BaseController
    {
        private readonly ISessionService _sessionService;
        private readonly IUserService _userService;

        public SessionController(ISessionService sessionService, IUserService userService)
        {
            _sessionService = sessionService;
            _userService = userService;
        }

        [HttpGet("overview")]
        [Authorize]
        public async Task<ActionResult<Pagination<SessionDto>>> GetSessionOverview([FromQuery] PaginationParams pagination)
        {
            var user = await _userService.FindByEmailFromClaimsPrinciple(HttpContext.User);
            if (user == null) return Unauthorized(new ApiException((int)HttpStatusCode.Unauthorized));

            var result = await _sessionService.GetSessions(user, pagination);
            return Resolve(result);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult<SessionDto>> CreateSession([FromQuery] int gameId)
        {
            var user = await _userService.FindByEmailFromClaimsPrinciple(HttpContext.User);
            if (user == null) return Unauthorized(new ApiException((int)HttpStatusCode.Unauthorized));

            var result = await _sessionService.CreateSession(user, gameId);
            return Resolve(result);
        }
    }
}
