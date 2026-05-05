namespace MedicalLabManagement.Domin.Entities
{
	public class Category : BaseEntity
	{
		public string EnName { get; set; } = string.Empty;
		public string ArName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public ICollection<Test> Tests { get; set; } = default!;
	}
}
