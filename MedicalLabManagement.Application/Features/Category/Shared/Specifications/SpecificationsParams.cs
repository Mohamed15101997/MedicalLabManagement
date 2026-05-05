namespace MedicalLabManagement.Application.Features.Category.Shared.Specifications
{
	public class SpecificationsParams
	{
		public int PageSize { get; set; } = 5;
		public int PageNumber { get; set; } = 1;
		public int Sort { get; set; } = 0;
	}
}
