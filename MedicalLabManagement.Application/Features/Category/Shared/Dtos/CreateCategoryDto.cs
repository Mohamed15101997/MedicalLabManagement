namespace MedicalLabManagement.Application.Features.Category.Shared.Dtos
{
	public class CreateCategoryDto
	{
		public string Code { get; set; }
		public string EnName { get; set; }
		public string ArName { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}
