using System.Net;

namespace Homework8_TaskManagerAPI.Models.Responce
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public ErrorMessage? ErrorMsg { get; set; }
        public required T Result { get; set; }

        public static ApiResult<Object> Error(HttpStatusCode statusCode, string errorMessage)
        {
            return new ApiResult<Object>()
            {
                Result = null!,
                IsSuccess = false,
                ErrorMsg = new ErrorMessage()
                {
                    Message = errorMessage,
                    StatusCode = Convert.ToInt32(statusCode)
                }
            };
        }

        public static ApiResult<T> Success (T result)
        {
            return new ApiResult<T>
            {
                Result = result,
                IsSuccess = true,
                ErrorMsg = null
            };
        }
    }
}
