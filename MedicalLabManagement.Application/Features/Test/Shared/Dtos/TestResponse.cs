using MedicalLabManagement.Domin.Enums;

namespace MedicalLabManagement.Application.Features.Test.Shared.Dtos
{
	public class TestResponse
	{
		public Guid Id { get; set; }
		public string Code { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public SampleType SampleType { get; set; }
		public Guid? CategoryId { get; set; }
		public string CategoryEnName { get; set; } = string.Empty;
		public string CategoryArName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsActive { get; set; } = true;
	}
}
