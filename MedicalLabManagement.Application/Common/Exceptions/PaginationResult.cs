namespace MedicalLabManagement.Application.Common.Exceptions
{
	public class PaginationResult<T>
	{
		public PaginationResult(int pageSize, int pageNumber, int total, IEnumerable<T> data)
		{
			PageSize = pageSize;
			PageNumber = pageNumber;
			Total = total;
			Data = data;
		}

		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public int Total { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}
