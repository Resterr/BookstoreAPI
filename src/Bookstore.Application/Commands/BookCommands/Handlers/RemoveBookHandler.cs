using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.BookCommands.Handlers;
internal sealed class RemoveBookHandler : ICommandHandler<RemoveBook>
{
	private readonly IBookRepository _repository;

	public RemoveBookHandler(IBookRepository repository)
	{
		_repository = repository;
	}

	public async Task HandleAsync(RemoveBook command)
	{
		var book = await _repository.GetAsync(command.Id);

		if (book is null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		await _repository.DeleteAsync(book);
	}
}
