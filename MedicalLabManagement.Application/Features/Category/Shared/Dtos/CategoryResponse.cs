namespace MedicalLabManagement.Application.Features.Category.Shared.Dtos
{
	public class CategoryResponse
	{
		public Guid Id { get; set; }
		public string Code { get; set; } = string.Empty;
		public string EnName { get; set; } = string.Empty;
		public string ArName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public List<TestResponse>? Tests { get; set; }
	}
}
