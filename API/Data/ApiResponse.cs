using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Data
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, T data, string message = null)
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
