using Bookstore.Application.Exceptions.OrderExceptions;
using Bookstore.Application.Services;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Factories.Abstractions;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Services;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.OrderCommands.Handlers;
internal sealed class CreateOrderHandler : ICommandHandler<CreateOrder>
{
	private readonly IOrderFactory _factory;
	private readonly IOrderRepository _orderRepository;
	private readonly IBookRepository _bookRepository;
	private readonly IUserRepository _userRepository;
	private readonly IUserContextService _userContext;
	private readonly IClock _clock;

	public CreateOrderHandler(IOrderFactory factory, IOrderRepository orderRepository, IBookRepository bookRepository, IUserRepository userRepository, IUserContextService userContext, IClock clock)
	{
		_factory = factory;
		_orderRepository = orderRepository;
		_bookRepository = bookRepository;
		_userRepository = userRepository;
		_userContext = userContext;
		_clock = clock;
	}

	public async Task HandleAsync(CreateOrder command)
	{
		var userId = _userContext.GetUserId;

		var user = await _userRepository.GetByIdAsync(userId);

		if (user == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), userId.GetValueOrNull());
		}

		var listOfBooks = new Dictionary<Book, BookQuantity>();

		foreach (var bookId in command.booksIdWithQuantity)
		{
			var book = await _bookRepository.GetAsync(bookId.Key);
			listOfBooks.Add(book, new BookQuantity(bookId.Value));
		}

		var availableInStock = listOfBooks.All(x => x.Key.Quantity >= x.Value);

		if(!availableInStock)
		{
			throw new BookNotAvailableException();
		}

		var creationDate = _clock.Current();
		var order = _factory.Create(command.Id, Shared.Consts.OrderStatus.Pending, user, creationDate, listOfBooks);

		await _orderRepository.AddAsync(order);

		foreach (var element in listOfBooks)
		{
			var book = element.Key;
			book.UpdateQuantity(book.Quantity - element.Value);
			await _bookRepository.UpdateAsync(book);
		}
	}
}
