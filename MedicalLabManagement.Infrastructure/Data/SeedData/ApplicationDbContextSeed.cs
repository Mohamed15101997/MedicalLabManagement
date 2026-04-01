using MedicalLabManagement.Domin.Entities;
using MedicalLabManagement.Infrastructure.Data.Contexts;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedicalLabManagement.Infrastructure.Data.SeedData
{
	public class ApplicationDbContextSeed
	{
		public static async Task SeedData(ApplicationDbContext context) 
		{
			// Category
			if (!context.Categories.Any()) 
			{
				var categoriesData = File.ReadAllText(@"..\MedicalLabManagement.Infrastructure\Data\SeedData\Data\CategoriesSeed.json");

				var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

				if(categories is not null && categories.Any()) 
				{
					await context.Categories.AddRangeAsync(categories);
				}
			}
			await context.SaveChangesAsync();
		}
	}
}
