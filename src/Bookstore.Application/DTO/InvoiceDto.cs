namespace Bookstore.Application.DTO;
public class InvoiceDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public double TotalCost { get; set; }
    public List<InvoiceBookDto> Books { get; set; }
    
}
