namespace MedicalLabManagement.Application.Interfaces.Repositories
{
	public interface IGenericRepositories<T> where T : BaseEntity
	{
		Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec,CancellationToken cancellationToken = default);
		Task<T?> GetByIdAsync(Guid id , CancellationToken cancellationToken = default);
		Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
		Task AddAsync(T entity, CancellationToken cancellationToken = default);
		void Update(T entity);
		void Delete(T entity);
		Task<int> GetCount();
		Task<int> GetCountWithSpec(ISpecification<T> spec);
		Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate , CancellationToken token);

	}
}
