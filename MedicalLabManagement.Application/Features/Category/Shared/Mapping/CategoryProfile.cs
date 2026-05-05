namespace MedicalLabManagement.Application.Features.Category.Shared.Mapping
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			MapEntity();
		}
		private void MapEntity()
		{
			CreateMap<CategoryModel, CategoryResponse>().ReverseMap();
			CreateMap<CategoryModel, CreateCategoryDto>().ReverseMap();
		}
	}
}
