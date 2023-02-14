using Bookstore.Application.DTO;
namespace Bookstore.Application.Services;
public interface IEmailSender
{
    public Task SendInvoiceAsync(InvoiceDto invoiceData);
}
