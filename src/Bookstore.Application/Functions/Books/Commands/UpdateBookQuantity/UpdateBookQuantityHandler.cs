using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Books.Commands.UpdateBookQuantity;
internal sealed class UpdateBookQuantityHandler : ICommandHandler<UpdateBookQuantity>
{
	private readonly IBookRepository _repository;

	public UpdateBookQuantityHandler(IBookRepository repository)
	{
		_repository = repository;
	}

	public async Task HandleAsync(UpdateBookQuantity command)
	{
		var book = await _repository.GetAsync(command.Id);

		if (book is null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		book.UpdateQuantity(command.Quantity);

		await _repository.UpdateAsync(book);
	}
}
