namespace Bookstore.Application.DTO;
public class OrderDto
{
	public Guid Id { get;  set; }
	public UserDto CreatedBy { get; set; }
	public string OrderStatus { get; set; }
	public DateTime? CreationDate { get; set; }
	public IEnumerable<BookDto> Books { get;  set; }
}
