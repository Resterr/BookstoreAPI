using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Publishers.Commands.EditPublisher;
public class EditPublisherHandler : ICommandHandler<EditPublisher>
{
	private readonly IPublisherRepository _repository;

	public EditPublisherHandler(IPublisherRepository repository)
	{
		_repository = repository;
	}

	public async Task HandleAsync(EditPublisher command)
	{
		var publisher = await _repository.GetAsync(command.Id);

		if (publisher is null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		publisher.UpdatePublisher(command.Name);

		await _repository.UpdateAsync(publisher);
	}
}
