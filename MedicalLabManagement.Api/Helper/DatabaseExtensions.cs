using MedicalLabManagement.Infrastructure.Data.Contexts;
using MedicalLabManagement.Infrastructure.Data.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MedicalLabManagement.Api.Helper
{
	public static class DatabaseExtensions
	{
		public static async Task ApplyDatabaseSetupAsync(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();

			var services = scope.ServiceProvider;

			var context = services.GetRequiredService<ApplicationDbContext>();
			var logger = services.GetRequiredService<ILogger<Program>>();

			try
			{			
				logger.LogInformation("Applying migrations...");
				await context.Database.MigrateAsync();

				logger.LogInformation("Seeding database...");
				await ApplicationDbContextSeed.SeedData(context);

				logger.LogInformation("Database setup completed successfully.");
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "An error occurred during database setup (migration or seeding).");
			}
		}
	}
}
