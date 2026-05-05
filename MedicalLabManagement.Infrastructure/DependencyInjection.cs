namespace MedicalLabManagement.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration) 
		{
			AddDbContextService(services,configuration);
			AddUserDefinedService(services);
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
		private static IServiceCollection AddUserDefinedService(IServiceCollection services)
		{
			// Inject Services
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;
		}
	}
}
