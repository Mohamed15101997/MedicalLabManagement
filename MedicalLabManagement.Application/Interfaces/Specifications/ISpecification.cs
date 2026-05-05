namespace MedicalLabManagement.Application.Interfaces.Specifications
{
	public interface ISpecification<T> where T : BaseEntity
	{
		Expression<Func<T,bool>>? Criteria { get; set; }
		List<Expression<Func<T,object>>> Includes { get; set; }
		Expression<Func<T, object>>? OrderBy { get; set; }
		Expression<Func<T, object>>? OrderByDescending { get; set; }
		int Skip { get; set; }
		int Take { get; set; }
		bool IsPaginationEnabled { get; set; }
	}
}
