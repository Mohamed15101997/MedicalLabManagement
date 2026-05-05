namespace MedicalLabManagement.Application.Features.Category.Shared.Specifications
{
	public class CategorySpecification : Specification<CategoryModel>
	{
		public CategorySpecification(Guid id) : base(p => p.Id == id)
		{
			AddInclude(p => p.Tests);
		}
		public CategorySpecification(SpecificationsParams param)
		{			
			AddInclude(p => p.Tests);
			AddPagination(param.PageSize * (param.PageNumber - 1), param.PageSize);
			if (param.Sort != 0)
			{
				switch (param.Sort)
				{
					case (int)CategorySort.EnNameAsc:
						AddOrderBy(p => p.EnName);
						break;
					case (int)CategorySort.EnNameDesc:
						AddOrderByDescending(p => p.EnName);
						break;
					case (int)CategorySort.ArNameAsc:
						AddOrderBy(p => p.ArName);
						break;
					case (int)CategorySort.ArNameDesc:
						AddOrderByDescending(p => p.ArName);
						break;
					case (int)CategorySort.CodeAsc:
						AddOrderBy(p => p.Code);
						break;
					case (int)CategorySort.CodeDesc:
						AddOrderByDescending(p => p.Code);
						break;
					default:
						AddOrderBy(p => p.EnName);
						break;
				}
			}
			else
			{
				AddOrderBy(p => p.EnName);
			}

		}
	}
}
