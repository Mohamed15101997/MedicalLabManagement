namespace MedicalLabManagement.Application.Features.Category.GetCategoryById
{
	public record GetCategoryByIdQuery(Guid id) : IRequest<Result<CategoryResponse>>;
}
