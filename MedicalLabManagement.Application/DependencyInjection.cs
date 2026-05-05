using MedicalLabManagement.Application.Common.Behaviors;
using Microsoft.AspNetCore.Mvc;

namespace MedicalLabManagement.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services ) 
		{
			var assembly = typeof(DependencyInjection).Assembly;
			// Register MediatR
			services.AddMediatR(config =>
			config.RegisterServicesFromAssemblies(assembly));

			// Register FluentValidation
			services.AddValidatorsFromAssembly(assembly);
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			// ModelState Validtaions 
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = (actionContext) =>
				{
					var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
											.SelectMany(p => p.Value.Errors)
											.Select(e => e.ErrorMessage)
											.ToArray();

					var response = Result<IEnumerable<string>>
						.Failure(errors, Error.Validation("Validation Errors"));

					return new BadRequestObjectResult(response);
				};
			});

			services.AddAutoMapper(m =>
			{
				m.AddProfile(new CategoryProfile());
				m.AddProfile(new TestProfile());
			});


			return services;
		}
		
	}
}
