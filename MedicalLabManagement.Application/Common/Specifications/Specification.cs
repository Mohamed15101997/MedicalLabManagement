namespace MedicalLabManagement.Application.Common.Specifications
{
	public class Specification<T> : ISpecification<T> where T : BaseEntity
	{
		public Expression<Func<T, bool>>? Criteria { get; set; }
		public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
		public Expression<Func<T, object>>? OrderBy { get ; set ; }
		public Expression<Func<T, object>>? OrderByDescending { get ; set ; }
		public int Skip { get ; set ; }
		public int Take { get ; set ; }
		public bool IsPaginationEnabled { get ; set ; }
		public Specification()
		{
			
		}
		public Specification(Expression<Func<T, bool>> expression)
		{
			Criteria = expression;
		}
		public void AddInclude(Expression<Func<T, object>> include)
		{
			Includes.Add(include);
		}
		public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
		{
			OrderBy = orderByExpression;
		}
		public void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
		{
			OrderByDescending = orderByDescExpression;
		}
		public void AddPagination(int skip , int take)
		{
			Skip = skip;
			Take = take;
			IsPaginationEnabled = true;
		}
	}
}
