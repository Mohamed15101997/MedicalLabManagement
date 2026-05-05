using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MedicalLabManagement.Application.Common.Exceptions
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;
		private readonly IHostEnvironment _env;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
		{
			_next = next;
			_logger = logger;
			_env = env;
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				var options = new JsonSerializerOptions()
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				};

				if (ex is ValidationException validationException)
				{
					context.Response.StatusCode = StatusCodes.Status400BadRequest;

					var errors = validationException.Errors
						.Select(e => e.ErrorMessage)
						.ToArray();

					var responseValidationError = Result<IEnumerable<string>>
						.Failure(errors, Error.Validation("Validation Errors"));

					var jsonValidationError = JsonSerializer.Serialize(responseValidationError, options);
					await context.Response.WriteAsync(jsonValidationError);
					return;
				}

				context.Response.ContentType = "application/json";
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;

				var response = _env.IsDevelopment() ?
					Error.InternalServer($"{ex.InnerException?.Message ?? ex.Message}") :
					Error.InternalServer($"{ex?.Message}");

				var json = JsonSerializer.Serialize(response, options);
				await context.Response.WriteAsync(json);

			}

		}

	}
}
