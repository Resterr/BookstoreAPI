namespace Bookstore.Application.Queries;

public interface IPagedResult<T> where T : class
{
	List<T> Items { get; set; }
	int ItemsFrom { get; set; }
	int ItemsTo { get; set; }
	int TotalItemsCount { get; set; }
	int TotalPages { get; set; }
}
