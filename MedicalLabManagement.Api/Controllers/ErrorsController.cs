namespace MedicalLabManagement.Api.Controllers
{
	[Route("error/{code}")]
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorsController : ControllerBase
	{
		public IActionResult Errors(int code)
		{
			return Ok(Result.Failure(Error.NotFound("Not Found Page!")));
		}
	}
}
