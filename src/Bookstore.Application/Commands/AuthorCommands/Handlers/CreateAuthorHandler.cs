using Bookstore.Domain.Factories;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.AuthorCommands.Handlers;
internal sealed class CreateAuthorHandler : ICommandHandler<CreateAuthor>
{
	private readonly IAuthorFactory _factory;
	private readonly IAuthorRepository _repository;

	public CreateAuthorHandler(IAuthorFactory factory, IAuthorRepository repository)
	{
		_factory = factory;
		_repository = repository;
	}

	public async Task HandleAsync(CreateAuthor command)
	{
		var author = _factory.Create(command.Id, command.FullName);

		await _repository.AddAsync(author);
	}
}
