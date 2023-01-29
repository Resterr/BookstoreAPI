using Bookstore.Domain.Factories.Abstractions;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Publishers.Commands.CreatePublisher;
internal sealed class CreatePublisherHandler : ICommandHandler<CreatePublisher>
{
	private readonly IPublisherFactory _factory;
	private readonly IPublisherRepository _repository;

	public CreatePublisherHandler(IPublisherFactory factory, IPublisherRepository repository)
	{
		_factory = factory;
		_repository = repository;
	}

	public async Task HandleAsync(CreatePublisher command)
	{
		var publisher = _factory.Create(command.Id, command.Name);

		await _repository.AddAsync(publisher);
	}
}
