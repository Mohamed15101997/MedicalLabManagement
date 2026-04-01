using MedicalLabManagement.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MedicalLabManagement.Infrastructure.Data.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
			: base(options)
		{
			
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Test> Tests { get; set; }
	}
}
