using API.Data;
using System.Collections.Generic;
using System.Net;

namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse<IEnumerable<string>>
    {
        public ApiValidationErrorResponse(string[] errors) : base((int) HttpStatusCode.BadRequest, errors)
        {
        }
    }
}