namespace MedicalLabManagement.Infrastructure.Persistence.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private Hashtable _repositories; 

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}
		public IGenericRepositories<T> Repository<T>() where T : BaseEntity
		{
			if (_repositories is null)
				_repositories = new Hashtable();

			var type = typeof(T).Name;

			if (!_repositories.ContainsKey(type)) 
			{
				var repository = new GenericRepositories<T>(_context);

				_repositories.Add(type,repository);
			}

			return _repositories[type] as IGenericRepositories<T>;
		}

		public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
