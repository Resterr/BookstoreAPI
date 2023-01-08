using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.BookCommands.Handlers;
internal sealed class ChangeBookPublisherHandler : ICommandHandler<ChangeBookPublisher>
{
	private readonly IBookRepository _bookRepository;
	private readonly IPublisherRepository _publisherRepository;

	public ChangeBookPublisherHandler(IBookRepository bookRepository, IPublisherRepository publisherRepository)
	{
		_bookRepository = bookRepository;
		_publisherRepository = publisherRepository;
	}

	public async Task HandleAsync(ChangeBookPublisher command)
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

		book.ChangePublisher(publisher);

		await _bookRepository.UpdateAsync(book);
	}
}
