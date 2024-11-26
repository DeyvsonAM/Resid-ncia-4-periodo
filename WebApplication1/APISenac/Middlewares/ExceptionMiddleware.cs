using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace APISenac.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Passa a requisição para o próximo middleware no pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log detalhado da exceção
                _logger.LogError(ex, $"[ExceptionMiddleware] Erro capturado: {ex.Message}");

                // Tratamento da resposta de erro
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Resposta JSON detalhada
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Ocorreu um erro no servidor. Tente novamente mais tarde.",
                Detailed = exception.Message // Apenas para desenvolvimento (remova em produção)
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
