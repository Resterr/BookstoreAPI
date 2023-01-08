using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.BookCommands.Handlers;
internal sealed class AddBookPublisherHandler : ICommandHandler<AddBookPublisher>
{
	private readonly IBookRepository _bookRepository;
	private readonly IPublisherRepository _publisherRepository;

	public AddBookPublisherHandler(IBookRepository bookRepository, IPublisherRepository publisherRepository)
	{
		_bookRepository = bookRepository;
		_publisherRepository = publisherRepository;
	}

	public async Task HandleAsync(AddBookPublisher command)
	{
		var book = await _bookRepository.GetAsync(command.BookId);

		if (book == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.BookId);
		}

		var publisher = await _publisherRepository.GetAsync(command.PublisherId);

		if (publisher == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.PublisherId);
		}

		book.AddPublisher(publisher);

		await _bookRepository.UpdateAsync(book);
	}
}
