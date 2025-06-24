namespace Homework8_TaskManagerAPI.Models.Responce
{
    public class ErrorMessage
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }
    }
}
