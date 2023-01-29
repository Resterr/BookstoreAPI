using Bookstore.Application.DTO;
using Bookstore.Application.Functions.Orders.Commands.AddBookToOrder;
using Bookstore.Application.Functions.Orders.Commands.ChangeBookQuantity;
using Bookstore.Application.Functions.Orders.Commands.ChangeStatus;
using Bookstore.Application.Functions.Orders.Commands.CreateOrder;
using Bookstore.Application.Functions.Orders.Commands.RemoveBookFromOrder;
using Bookstore.Application.Functions.Orders.Commands.RemoveOrderHandler;
using Bookstore.Application.Functions.Orders.Queries.GetOrderById;
using Bookstore.Application.Functions.Orders.Queries.GetOrdersForCurrentUser;
using Bookstore.Application.Functions.Orders.Queries.SearchOrders;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

[Authorize]
public class OrdersController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;

	public OrdersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
	}

	[Authorize(Policy = "is-admin")]
	[HttpGet("{id:Guid}")]
	public async Task<ActionResult<OrderDto>> Get([FromRoute] GetOrderById query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[HttpGet("currentUser")]
	public async Task<ActionResult<IPagedResult<OrderDto>>> GetForCurrentUser([FromQuery] GetOrdersForCurrentUser query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[Authorize(Policy = "is-admin")]
	[HttpGet]
	public async Task<ActionResult<IPagedResult<OrderDto>>> Get([FromQuery] SearchOrders query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CreateOrder command)
	{
		command = command with { Id = Guid.NewGuid() };
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[Authorize(Policy = "is-admin")]
	[HttpPut("{orderId:Guid}/status")]
	public async Task<IActionResult> Put([FromRoute] Guid orderId, ChangeStatus command)
	{
		command = command with { Id = orderId };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[Authorize(Policy = "is-admin")]
	[HttpPut("{orderId:Guid}/add")]
	public async Task<IActionResult> Put([FromRoute] Guid orderId, [FromBody] AddBookToOrder command)
	{
		command = command with { OrderId = orderId };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[Authorize(Policy = "is-admin")]
	[HttpPut("{orderId:Guid}/change")]
	public async Task<IActionResult> Put([FromRoute] Guid orderId, [FromBody] ChangeBookQuantity command)
	{
		command = command with { OrderId = orderId};
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[Authorize(Policy = "is-admin")]
	[HttpPut("{orderId:Guid}/remove")]
	public async Task<IActionResult> Put([FromRoute] Guid orderId, [FromBody] RemoveBookFromOrder command)
	{
		command = command with { OrderId = orderId };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[Authorize(Policy = "is-admin")]
	[HttpDelete("{id:Guid}")]
	public async Task<IActionResult> Delete([FromRoute] RemoveOrder command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return NoContent();
	}
}
