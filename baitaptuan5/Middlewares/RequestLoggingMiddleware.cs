using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace baitaptuan5.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();

            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var method = context.Request.Method;
            var path = context.Request.Path.ToString();

            // Chức năng 3: Chặn truy cập URL không hợp lệ (ID = 0 hoặc ID = -1)
            if (path.Equals("/Book/Detail/0", StringComparison.OrdinalIgnoreCase) ||
                path.Equals("/Book/Detail/-1", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Book id khong hop le");
                return; // Dừng request, không cho đi tiếp vào Controller
            }

            // Chức năng 1: Ghi log request ra Console
            Console.WriteLine($"[{time}] Method: {method} - Path: {path}");

            // Cho request tiếp tục đi vào pipeline (Controller)
            await _next(context);

            sw.Stop();

            // Chức năng 2: Ghi log Status Code và thời gian xử lý (ms)
            Console.WriteLine($"Status Code: {context.Response.StatusCode} | Duration: {sw.ElapsedMilliseconds} ms");
        }
    }
}