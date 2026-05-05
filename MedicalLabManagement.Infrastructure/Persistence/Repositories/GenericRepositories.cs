using System.Linq.Expressions;

namespace MedicalLabManagement.Infrastructure.Persistence.Repositories
{
	public class GenericRepositories<T> : IGenericRepositories<T> where T : BaseEntity
	{
		private readonly ApplicationDbContext _context;
		public GenericRepositories(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _context.Set<T>().ToListAsync(cancellationToken);
		}
		public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
		{
			return await ApplySpecifications(spec).ToListAsync(cancellationToken);
		}
		public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
		{
			return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
		}
		public async Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
		{
			return await ApplySpecifications(spec).FirstOrDefaultAsync(cancellationToken);
		}
		public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
		{
			await _context.Set<T>().AddAsync(entity, cancellationToken);
		}
		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}
		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}
		public async Task<int> GetCount()
		{
			return await _context.Set<T>().CountAsync();
		}
		public async Task<int> GetCountWithSpec(ISpecification<T> spec)
		{
			return await ApplySpecifications(spec).CountAsync();
		}
		public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate , CancellationToken token)
		{
			return await _context.Set<T>().AnyAsync(predicate,token);
		}
		private IQueryable<T> ApplySpecifications(ISpecification<T> spec) => 
			SpecificationsEvaluator<T>.GetQuery(_context.Set<T>(), spec);

	}
}
