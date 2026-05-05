namespace MedicalLabManagement.Application.Features.Category.GetAllCategories
{
	public record GetAllCategoriesQuery(SpecificationsParams param) : IRequest<Result<PaginationResult<CategoryResponse>>>;
}
