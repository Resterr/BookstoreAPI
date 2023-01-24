using Bookstore.Application.DTO;
using Bookstore.Application.Functions.Publishers.Commands.CreatePublisher;
using Bookstore.Application.Functions.Publishers.Commands.EditPublisher;
using Bookstore.Application.Functions.Publishers.Commands.RemovePublisher;
using Bookstore.Application.Functions.Publishers.Queries.GetPublisherById;
using Bookstore.Application.Functions.Publishers.Queries.SearchPublishers;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

[Authorize(Policy = "is-admin")]
public class PublishersController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;

	public PublishersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
	}

	[AllowAnonymous]
	[HttpGet("{id:Guid}")]
	public async Task<ActionResult<PublisherDto>> Get([FromRoute] GetPublisherById query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[AllowAnonymous]
	[HttpGet]
	public async Task<ActionResult<IPagedResult<PublisherDto>>> Get([FromQuery] SearchPublishers query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CreatePublisher command)
	{
		command = command with { Id = Guid.NewGuid() };
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[HttpPut("{id:Guid}")]
	public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EditPublisher command)
	{
		command = command with { Id = id };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpDelete("{id:Guid}")]
	public async Task<IActionResult> Delete([FromRoute] RemovePublisher command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return NoContent();
	}
}
