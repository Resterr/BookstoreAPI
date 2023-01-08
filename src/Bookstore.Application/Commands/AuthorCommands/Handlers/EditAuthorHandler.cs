using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.AuthorCommands.Handlers;
internal sealed class EditAuthorHandler : ICommandHandler<EditAuthor>
{
	private readonly IAuthorRepository _repository;

	public EditAuthorHandler(IAuthorRepository repository)
	{
		_repository = repository;
	}

	public async Task HandleAsync(EditAuthor command)
	{
		var author = await _repository.GetAsync(command.Id);

		if (author is null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		author.UpdateAuthor(command.FullName);

		await _repository.UpdateAsync(author);
	}
}
