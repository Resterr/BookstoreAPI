using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Publishers.Commands.RemovePublisher;
public class RemovePublisherHandler : ICommandHandler<RemovePublisher>
{
	private readonly IPublisherRepository _repository;

	public RemovePublisherHandler(IPublisherRepository repository)
	{
		_repository = repository;
	}

	public async Task HandleAsync(RemovePublisher command)
	{
		var publisher = await _repository.GetAsync(command.Id);

		if (publisher is null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		await _repository.DeleteAsync(publisher);
	}
}
