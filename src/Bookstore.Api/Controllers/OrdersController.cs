using Bookstore.Application.Commands.OrderCommands;
using Bookstore.Application.DTO;
using Bookstore.Application.Queries;
using Bookstore.Application.Queries.OrderQueries;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Queries;
using Bookstore.Shared.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

[Authorize]
public class OrdersController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;
	private readonly IIdGeneratorService _idGenerator;

	public OrdersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IIdGeneratorService idGenerator)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
		_idGenerator = idGenerator;
	}

	[Authorize(Policy = "is-admin")]
	[HttpGet("{id:long}")]
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
		command = command with { Id = _idGenerator.Generate() };
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[Authorize(Policy = "is-admin")]
	[HttpPut("{orderId:long}/change/status")]
	public async Task<IActionResult> Put([FromRoute] long orderId, ChangeStatus command)
	{
		command = command with { Id = orderId };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[Authorize(Policy = "is-admin")]
	[HttpPut("{orderId:long}/add")]
	public async Task<IActionResult> Put([FromRoute] long orderId, [FromBody] AddBookToOrder command)
	{
		command = command with { OrderId = orderId };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[Authorize(Policy = "is-admin")]
	[HttpPut("{orderId:long}/change")]
	public async Task<IActionResult> Put([FromRoute] long orderId, [FromBody] ChangeBookQuantity command)
	{
		command = command with { OrderId = orderId};
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[Authorize(Policy = "is-admin")]
	[HttpPut("{orderId:long}/remove")]
	public async Task<IActionResult> Put([FromRoute] long orderId, [FromBody] RemoveBookFromOrder command)
	{
		command = command with { OrderId = orderId };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[Authorize(Policy = "is-admin")]
	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete([FromRoute] RemoveOrder command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return NoContent();
	}
}
