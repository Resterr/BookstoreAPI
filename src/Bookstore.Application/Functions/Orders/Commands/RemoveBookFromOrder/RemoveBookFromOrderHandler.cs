using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Orders.Commands.RemoveBookFromOrder;
internal sealed class RemoveBookFromOrderHandler : ICommandHandler<RemoveBookFromOrder>
{
	private readonly IOrderRepository _orderRepository;
	private readonly IBookRepository _bookRepository;

	public RemoveBookFromOrderHandler(IOrderRepository orderRepository, IBookRepository bookRepository)
	{
		_orderRepository = orderRepository;
		_bookRepository = bookRepository;
	}

	public async Task HandleAsync(RemoveBookFromOrder command)
	{
		var order = await _orderRepository.GetAsync(command.OrderId);

		if (order == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.OrderId);
		}

		var book = order.Books.SingleOrDefault(x => x.BookId.Value == command.BookId).Book;

		if (book == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.BookId);
		}

		order.RemoveBook(book);
		book.UpdateQuantity(book.Quantity + book.Quantity);

		await _orderRepository.UpdateAsync(order);
		await _bookRepository.UpdateAsync(book);
	}
}
