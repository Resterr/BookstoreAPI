using Bookstore.Domain.Factories;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands.Handlers;
internal sealed class CreateBookHandler : ICommandHandler<CreateBook>
{
	private readonly IBookFactory _factory;
	private readonly IBookRepository _repository;

	public CreateBookHandler(IBookFactory factory, IBookRepository repository)
	{
		_factory = factory;
		_repository = repository;
	}

	public async Task HandleAsync(CreateBook command)
	{
		var book = _factory.Create(command.Id, command.Name, command.Price, command.CoverType,
			command.NumberOfPages, command.Height, command.Width, command.Quantity);

		await _repository.AddAsync(book);
	}
}
