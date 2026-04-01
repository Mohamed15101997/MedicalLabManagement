namespace MedicalLabManagement.Domin.Entities
{
	public abstract class BaseEntity
	{
		public Guid Id { get; set; } =  Guid.NewGuid();
		public string Code { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	}
}
