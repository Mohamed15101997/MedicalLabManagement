namespace MedicalLabManagement.Application.Common.Exceptions
{
	public record Error(string Code , string Description , int? StatusCode)
	{
		public static Error None = new (string.Empty, string.Empty, null);
		public static Error NotFound(string description) => new("NotFound", description, 404);
		public static Error CrudFailed(string code,string description) => new(code, description, 500);
		public static Error InternalServer(string description) => new("InternalServer", description, 500);
		public static Error Validation(string description) => new("Validation", description, 400);
	}
}
