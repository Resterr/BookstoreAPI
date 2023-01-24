using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Books.Commands.AddBookAuthor;
internal sealed class AddBookAuthorHandler : ICommandHandler<AddBookAuthor>
{
	private readonly IBookRepository _bookRepository;
	private readonly IAuthorRepository _authorRepository;

	public AddBookAuthorHandler(IBookRepository bookRepository, IAuthorRepository authorRepository)
	{
		_bookRepository = bookRepository;
		_authorRepository = authorRepository;
	}

	public async Task HandleAsync(AddBookAuthor command)
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

		book.AddAuthor(author);

		await _bookRepository.UpdateAsync(book);
	}
}
