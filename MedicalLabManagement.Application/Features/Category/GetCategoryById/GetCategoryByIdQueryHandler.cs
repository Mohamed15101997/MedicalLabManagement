namespace MedicalLabManagement.Application.Features.Category.GetCategoryById
{
	public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryResponse>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork , IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
		{
			var spec = new CategorySpecification(request.id);

			var category = await _unitOfWork.Repository<CategoryModel>().GetEntityWithSpecAsync(spec , cancellationToken);

			if(category is null)
				return Result<CategoryResponse>.Failure(Error.NotFound($"Category With Id {request.id} Not Found"));

			var mappedCategory = _mapper.Map<CategoryResponse>(category);

			return Result<CategoryResponse>.Success(mappedCategory);
		}
	}
}
