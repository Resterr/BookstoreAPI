using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Books.Commands.RemoveBookPublisher;
internal sealed class RemoveBookPublisherHandler : ICommandHandler<RemoveBookPublisher>
{
	private readonly IBookRepository _bookRepository;
	private readonly IPublisherRepository _publisherRepository;

	public RemoveBookPublisherHandler(IBookRepository bookRepository, IPublisherRepository publisherRepository)
	{
		_bookRepository = bookRepository;
		_publisherRepository = publisherRepository;
	}

	public async Task HandleAsync(RemoveBookPublisher command)
	{
		var book = await _bookRepository.GetAsync(command.BookId);

		if (book == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.BookId);
		}

		book.RemovePublisher();

		await _bookRepository.UpdateAsync(book);
	}
}
