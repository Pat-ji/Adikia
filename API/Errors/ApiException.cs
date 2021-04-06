using API.Data;

namespace API.Errors
{
	public class ApiException : ApiResponse<string>
	{
		public ApiException(int statusCode, string details = null, string message = null)
			: base(statusCode, details, message)
		{
		}
	}
}
