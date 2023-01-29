using Bookstore.Application.Exceptions.OrderExceptions;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Orders.Commands.AddBookToOrder;
internal sealed class AddBookToOrderHandler : ICommandHandler<AddBookToOrder>
{
	private readonly IOrderRepository _orderRepository;
	private readonly IBookRepository _bookRepository;

	public AddBookToOrderHandler(IOrderRepository orderRepository, IBookRepository bookRepository)
	{
		_orderRepository = orderRepository;
		_bookRepository = bookRepository;
	}

	public async Task HandleAsync(AddBookToOrder command)
	{
		var order = await _orderRepository.GetAsync(command.OrderId);

		if (order == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.OrderId);
		}

		var book = await _bookRepository.GetAsync(command.BookId);

		if (book == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.OrderId);
		}

		if (book.Quantity < command.Quantity)
		{
			throw new BookNotAvailableException();
		}

		order.AddBook(book, command.Quantity);
		book.UpdateQuantity(book.Quantity - command.Quantity);

		await _orderRepository.UpdateAsync(order);
		await _bookRepository.UpdateAsync(book);
	}
}
