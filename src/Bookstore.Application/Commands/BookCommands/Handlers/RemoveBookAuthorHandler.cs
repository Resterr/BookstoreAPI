using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.BookCommands.Handlers;
internal sealed class RemoveBookAuthorHandler : ICommandHandler<RemoveBookAuthor>
{
	private readonly IBookRepository _bookRepository;
	private readonly IAuthorRepository _authorRepository;

	public RemoveBookAuthorHandler(IBookRepository bookRepository, IAuthorRepository authorRepository)
	{
		_bookRepository = bookRepository;
		_authorRepository = authorRepository;
	}

	public async Task HandleAsync(RemoveBookAuthor command)
	{
		var book = await _bookRepository.GetAsync(command.BookId);

		if (book == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.BookId);
		}

		var author = await _authorRepository.GetAsync(command.AuthorId);

		if (author == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.AuthorId);
		}

		book.RemoveAuthor(author);

		await _bookRepository.UpdateAsync(book);
	}
}
