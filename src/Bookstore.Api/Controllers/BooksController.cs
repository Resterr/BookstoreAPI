using Bookstore.Application.Commands.BookCommands;
using Bookstore.Application.DTO;
using Bookstore.Application.Queries;
using Bookstore.Application.Queries.BookQueries;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

[Authorize(Policy = "is-admin")]
public class BooksController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;

	public BooksController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
	}

	[AllowAnonymous]
	[HttpGet("{id:Guid}")]
    public async Task<ActionResult<BookDto>> Get([FromRoute] GetBookById query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

	[AllowAnonymous]
	[HttpGet]
    public async Task<ActionResult<IPagedResult<BookDto>>> Get([FromQuery] SearchBooks query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CreateBook command)
	{
		command = command with { Id = Guid.NewGuid() };
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[HttpPut("{id:Guid}")]
	public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EditBook command)
	{
		command = command with { Id = id };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpDelete("{id:Guid}")]
	public async Task<IActionResult> Delete([FromRoute] RemoveBook command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return NoContent();
	}

	[HttpPut("{bookId:Guid}/Author/Add/{authorId:Guid}")]
	public async Task<IActionResult> Put([FromRoute] AddBookAuthor command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{bookId:Guid}/Author/Remove/{authorId:Guid}")]
	public async Task<IActionResult> Put([FromRoute] RemoveBookAuthor command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{bookId:Guid}/Publisher/Add/{publisherId:Guid}")]
	public async Task<IActionResult> Put([FromRoute] AddBookPublisher command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{bookId:Guid}/Publisher/Change/{publisherId:Guid}")]
	public async Task<IActionResult> Put([FromRoute] ChangeBookPublisher command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{bookId:Guid}/Publisher/Remove/{publisherId:Guid}")]
	public async Task<IActionResult> Put([FromRoute] RemoveBookPublisher command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{id:Guid}/Quantity")]
	public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateBookQuantity command)
	{
		command = command with { Id = id };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}
}
