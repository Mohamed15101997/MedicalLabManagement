using MedicalLabManagement.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalLabManagement.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration) 
		{
			AddDbContextService(services,configuration);
			return services;
		}

		private static void AddDbContextService(IServiceCollection services, IConfiguration configuration)
		{
			string connection = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection Failed");
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(connection);
		    });
		}
	}
}
