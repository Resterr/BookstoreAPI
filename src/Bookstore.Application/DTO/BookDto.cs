namespace Bookstore.Application.DTO;
public class BookDto
{
	public long Id { get; set; }
	public string Name { get; set; }
	public double Price { get; set; }
	public string CoverType { get; set; }
	public int NumberOfPages { get; set; }
	public string Size { get; set; }
	public int Quantity { get; set; }
	public IEnumerable<AuthorDto> Authors { get; set; }
	public PublisherDto Publisher { get; set; }
}
