
namespace MedicalLabManagement.Application.Features.Category.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CreateCategoryCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = _mapper.Map<CategoryModel>(request.dto);

			await _unitOfWork.Repository<CategoryModel>().AddAsync(category);

			var result = await _unitOfWork.SaveChangeAsync();

			if (result > 0)
				return Result.Success();

			return Result.Failure(Error.CrudFailed($"{AppEntities.Category}.{CrudError.Add}", "Failed to Create Category"));
		}
	}
}
