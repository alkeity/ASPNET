using System.Diagnostics;

namespace Homework8_TaskManagerAPI.Middleware
{
    public class RequestTimeMiddleware
    {
        private const int MAX_RESPONCE_TIME = 500;

        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(RequestDelegate next, ILogger<RequestTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            await _next.Invoke(context);
            sw.Stop();

            long time = sw.ElapsedMilliseconds;

            if (time > MAX_RESPONCE_TIME)
            {
                _logger.LogWarning($"Responce time longer than usual: {time}ms (max allowed is {MAX_RESPONCE_TIME}ms)");
                return;
            }

            _logger.LogInformation($"Responce time: {time}ms");
        }
    }
}
