using Bookstore.Application.DTO;
using Bookstore.Application.Services;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Consts;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Orders.Commands.ChangeStatus;
public class ChangeStatusHandler : ICommandHandler<ChangeStatus>
{
	private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailSender _emailSender;

    public ChangeStatusHandler(IOrderRepository orderRepository, IUserRepository userRepository, IEmailSender emailSender)
	{
		_orderRepository = orderRepository;
        _userRepository = userRepository;
        _emailSender = emailSender;
    }

	public async Task HandleAsync(ChangeStatus command)
	{
		var order = await _orderRepository.GetAsync(command.Id);

		if (order == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		OrderStatus orderStatus = order.OrderStatus;

		switch(command.StatusName)
		{
			case "Pending" : 
				orderStatus = OrderStatus.Pending;
				break;
			case "Accepted":
				orderStatus = OrderStatus.Accepted;
				break;
			case "Canceled":
				orderStatus = OrderStatus.Canceled;
				break;
			case "Returned":
				orderStatus = OrderStatus.Returned;
				break;
		}

		order.StatusChange(orderStatus);

		await _orderRepository.UpdateAsync(order);

		if(order.OrderStatus == OrderStatus.Accepted) 
		{
			var user = await _userRepository.GetByIdAsync(order.CreatedBy.Id.Value);

			var invoiceData = new InvoiceDto
			{
				Id = order.Id.Value.ToString(),
				Email = user.Email,
				FullName = user.FullName,
				TotalCost = 0.0,
				Books = new List<InvoiceBookDto> { }
			};

			foreach (var book in order.Books) 
			{
				var invoiceBook = new InvoiceBookDto
				{
					Name = book.Book.Name,
					Price = book.Book.Price,
					Quantity = book.Quantity
				};

				invoiceData.Books.Add(invoiceBook);
				invoiceData.TotalCost += invoiceBook.Quantity * invoiceBook.Price;

            }

			await _emailSender.SendInvoiceAsync(invoiceData);
		}
	}
}
