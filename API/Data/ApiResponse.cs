namespace API.Data
{
    public class ApiResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(int statusCode, T data = null, string message = null)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                400 => "Bad request",
                401 => "Unauthorized",
                404 => "Resource not found",
                500 => "Internal server error",
                _ => $"Unknown status code {statusCode}"
            };
        }
    }
}
