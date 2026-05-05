


namespace MedicalLabManagement.Application.Features.Category.GetAllCategories
{
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery ,Result<PaginationResult<CategoryResponse>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork , IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<PaginationResult<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			var spec = new CategorySpecification(request.param);

			var categories = await _unitOfWork.Repository<CategoryModel>().GetAllWithSpecAsync(spec, cancellationToken);

			var count = await _unitOfWork.Repository<CategoryModel>().GetCount();

			var mappedCategories = _mapper.Map<List<CategoryResponse>>(categories);

			var result = new PaginationResult<CategoryResponse>(request.param.PageSize, request.param.PageNumber, count, mappedCategories);

			return Result<PaginationResult<CategoryResponse>>.Success(result);
		}
	}
}
