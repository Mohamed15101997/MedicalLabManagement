using MedicalLabManagement.Application.Features.Category.CreateCategory;

namespace MedicalLabManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IMediator _mediator;
		public CategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet("Category/{id}")]
		public async Task<ActionResult<Result<CategoryResponse>>> GetCategoryById(Guid id) 
		{
			var result = await _mediator.Send(new GetCategoryByIdQuery(id));
			return Ok(result);
		}
		[HttpPost("GetAllCategories")]
		public async Task<ActionResult<Result<List<CategoryResponse>>>> GetAll(SpecificationsParams param)
		{
			var result = await _mediator.Send(new GetAllCategoriesQuery(param));
			return Ok(result);
		}
		[HttpPost("CreateCategory")]
		public async Task<ActionResult<Result>> CreateCategory(CreateCategoryDto dto)
		{
			var result = await _mediator.Send(new CreateCategoryCommand(dto));
			return Ok(result);
		}
	}
}
