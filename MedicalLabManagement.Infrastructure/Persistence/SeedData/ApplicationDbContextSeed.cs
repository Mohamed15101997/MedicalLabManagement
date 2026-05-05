namespace MedicalLabManagement.Infrastructure.Persistence.SeedData
{
	public class ApplicationDbContextSeed
	{
		public static async Task SeedData(ApplicationDbContext context) 
		{
			// Category
			if (!context.Categories.Any()) 
			{
				var categoriesData = File.ReadAllText(@"..\MedicalLabManagement.Infrastructure\Persistence\SeedData\Data\CategoriesSeed.json");

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
