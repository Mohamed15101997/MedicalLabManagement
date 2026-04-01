using MedicalLabManagement.Domin.Enums;

namespace MedicalLabManagement.Domin.Entities
{
	public class Test : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public SampleType SampleType { get; set; }
		public Guid? CategoryId { get; set; }
		public Category? Category { get; set; }
		public string Description { get; set; } = string.Empty;
		public bool IsActive { get; set; } = true;
	}
}
