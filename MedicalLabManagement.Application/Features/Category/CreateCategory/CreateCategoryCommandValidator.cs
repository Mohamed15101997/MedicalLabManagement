namespace MedicalLabManagement.Application.Features.Category.CreateCategory
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateCategoryCommandValidator(IUnitOfWork unitOfWork)
		{
			RuleFor(x => x.dto)
				.NotNull()
				.WithMessage("Category date is required");

			RuleFor(x => x.dto.Code)
				.NotEmpty()
				.WithMessage("Category code is required")
				.MinimumLength(3)
				.WithMessage("Category code must be at least 3 characters")
				.MaximumLength(30)
				.WithMessage("Category code must not exceed 30 characters")
				.MustAsync(BeUniqueCode)
				.WithMessage("Category code already exists"); ;

			RuleFor(x => x.dto.EnName)
				.NotEmpty()
				.WithMessage("Category name en is required")
				.MaximumLength(50)
				.WithMessage("Category name en must not exceed 50 characters"); ;

			RuleFor(x => x.dto.ArName)
				.NotEmpty()
				.WithMessage("Category name ar is required")
				.MaximumLength(50)
				.WithMessage("Category name ar must not exceed 50 characters");

			_unitOfWork = unitOfWork;
		}
		private async Task<bool> BeUniqueCode(string code, CancellationToken token)
		{
			return !await _unitOfWork.Repository<CategoryModel>().ExistsAsync(x => x.Code == code , token);
		}
	}
}
