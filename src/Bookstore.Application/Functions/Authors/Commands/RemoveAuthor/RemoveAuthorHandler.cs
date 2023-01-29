using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Authors.Commands.RemoveAuthor;
internal sealed class RemoveAuthorHandler : ICommandHandler<RemoveAuthor>
{
	private readonly IAuthorRepository _repository;

	public RemoveAuthorHandler(IAuthorRepository repository)
	{
		_repository = repository;
	}

	public async Task HandleAsync(RemoveAuthor command)
	{
		var author = await _repository.GetAsync(command.Id);

		if (author is null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		await _repository.DeleteAsync(author);
	}
}
