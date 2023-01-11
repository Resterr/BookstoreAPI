using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Commands.OrderCommands.Handlers;
public class ChangeStatusHandler : ICommandHandler<ChangeStatus>
{
	private readonly IOrderRepository _orderRepository;

	public ChangeStatusHandler(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	public async Task HandleAsync(ChangeStatus command)
	{
		var order = await _orderRepository.GetAsync(command.Id);

		if (order == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		order.StatusChange(command.orderStatus);

		await _orderRepository.UpdateAsync(order);
	}
}
