using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.OrderCommands.Handlers;
internal sealed class RemoveOrderHandler : ICommandHandler<RemoveOrder>
{
	private readonly IOrderRepository _orderRepository;
	private readonly IBookRepository _bookRepository;

	public RemoveOrderHandler(IOrderRepository orderRepository, IBookRepository bookRepository)
	{
		_orderRepository = orderRepository;
		_bookRepository = bookRepository;
	}

	public async Task HandleAsync(RemoveOrder command)
	{
		var order = await _orderRepository.GetAsync(command.Id);

		if (order == null) 
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		foreach (var element in order.Books)
		{
			var book = element.Book;
			book.UpdateQuantity(book.Quantity + element.Quantity);
			await _bookRepository.UpdateAsync(book);
		}

		await _orderRepository.DeleteAsync(order);
	}
}
