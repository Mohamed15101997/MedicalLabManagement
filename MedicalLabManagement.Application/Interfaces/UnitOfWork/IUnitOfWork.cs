namespace MedicalLabManagement.Application.Interfaces.UnitOfWork
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
		IGenericRepositories<T> Repository<T>() where T : BaseEntity;
	}
}
