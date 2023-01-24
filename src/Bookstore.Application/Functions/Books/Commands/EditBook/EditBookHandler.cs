using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Books.Commands.EditBook;
internal sealed class EditBookHandler : ICommandHandler<EditBook>
{
	private readonly IBookRepository _repository;

	public EditBookHandler(IBookRepository repository)
	{
		_repository = repository;
	}

	public async Task HandleAsync(EditBook command)
	{
		var book = await _repository.GetAsync(command.Id);

		if (book is null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		book.UpdateBook(command.Name, command.Price, command.CoverType, command.NumberOfPages, command.Height, command.Width);

		await _repository.UpdateAsync(book);
	}
}
