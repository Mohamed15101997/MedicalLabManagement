namespace MedicalLabManagement.Application.Features.Category.CreateCategory
{
	public record CreateCategoryCommand(CreateCategoryDto dto) : IRequest<Result>;
}
