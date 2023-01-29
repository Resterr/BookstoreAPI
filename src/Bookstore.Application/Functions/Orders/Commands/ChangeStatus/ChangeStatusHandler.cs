using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Consts;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Orders.Commands.ChangeStatus;
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

		OrderStatus orderStatus = order.OrderStatus;

		switch(command.StatusName)
		{
			case "Pending" : 
				orderStatus = OrderStatus.Pending;
				break;
			case "Accepted":
				orderStatus = OrderStatus.Accepted;
				break;
			case "Canceled":
				orderStatus = OrderStatus.Canceled;
				break;
			case "Returned":
				orderStatus = OrderStatus.Returned;
				break;
		}

		order.StatusChange(orderStatus);

		await _orderRepository.UpdateAsync(order);
	}
}
