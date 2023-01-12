using Bookstore.Application.Exceptions.OrderExceptions;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.OrderCommands.Handlers;
internal sealed class ChangeBookQuantityHandler : ICommandHandler<ChangeBookQuantity>
{
	private readonly IOrderRepository _orderRepository;
	private readonly IBookRepository _bookRepository;

	public ChangeBookQuantityHandler(IOrderRepository orderRepository, IBookRepository bookRepository)
	{
		_orderRepository = orderRepository;
		_bookRepository = bookRepository;
	}

	public async Task HandleAsync(ChangeBookQuantity command)
	{
		var order = await _orderRepository.GetAsync(command.OrderId);

		if (order == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.OrderId);
		}

		var orderBook = order.Books.SingleOrDefault(x => x.BookId == command.BookId);

		if (orderBook == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.BookId);
		}

		var book = orderBook.Book;

		if (orderBook.Quantity > command.Quantity)
		{
			order.ChangeOrderBookQuantity(book, command.Quantity);
			book.UpdateQuantity(book.Quantity + command.Quantity);
		}

		else if (orderBook.Quantity < command.Quantity)
		{
			if (book.Quantity < (command.Quantity - orderBook.Quantity))
			{
				throw new BookNotAvailableException();
			}

			order.ChangeOrderBookQuantity(book, command.Quantity);

			book.UpdateQuantity(book.Quantity - (command.Quantity - orderBook.Quantity));	
		}

		else
		{
			throw new SameQuantityValueException();
		}

		await _orderRepository.UpdateAsync(order);

		await _bookRepository.UpdateAsync(book);
	}
}
