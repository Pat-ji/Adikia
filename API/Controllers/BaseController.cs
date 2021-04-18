using API.Data;
using API.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected ActionResult Resolve<T>(ApiResponse<T> response) where T : class
        {
            return response.StatusCode switch
            {
                (int)HttpStatusCode.OK => Ok(response),
                (int)HttpStatusCode.Unauthorized => Unauthorized(response),
                _ => BadRequest(response),
            };
        }
    }
}
