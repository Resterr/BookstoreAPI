using Bookstore.Application.Commands.AuthorCommands;
using Bookstore.Application.DTO;
using Bookstore.Application.Queries;
using Bookstore.Application.Queries.AuthorQueries;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

[Authorize(Policy = "is-admin")]
public class AuthorsController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;

	public AuthorsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
	}

	[AllowAnonymous]
	[HttpGet("{id:Guid}")]
	public async Task<ActionResult<AuthorDto>> Get([FromRoute] GetAuthorById query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[AllowAnonymous]
	[HttpGet]
	public async Task<ActionResult<IPagedResult<AuthorDto>>> Get([FromQuery] SearchAuthors query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CreateAuthor command)
	{
		command = command with { Id = Guid.NewGuid() };
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[HttpPut("{id:Guid}")]
	public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EditAuthor command)
	{
		command = command with { Id = id };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpDelete("{id:Guid}")]
	public async Task<IActionResult> Delete([FromRoute] RemoveAuthor command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return NoContent();
	}
}
