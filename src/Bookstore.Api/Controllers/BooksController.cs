using Bookstore.Application.Commands.BookCommands;
using Bookstore.Application.DTO;
using Bookstore.Application.Queries;
using Bookstore.Application.Queries.BookQueries;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Queries;
using Bookstore.Shared.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

[Authorize(Policy = "is-admin")]
public class BooksController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;
	private readonly IIdGeneratorService _idGenerator;

	public BooksController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IIdGeneratorService idGenerator)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
		_idGenerator = idGenerator;
	}

	[AllowAnonymous]
	[HttpGet("{id:long}")]
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
		command = command with { Id = _idGenerator.Generate() };
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[HttpPut("{id:long}")]
	public async Task<IActionResult> Put([FromRoute] long id, [FromBody] EditBook command)
	{
		command = command with { Id = id };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete([FromRoute] RemoveBook command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return NoContent();
	}

	[HttpPut("{bookId:long}/Author/Add/{authorId:long}")]
	public async Task<IActionResult> Put([FromRoute] AddBookAuthor command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{bookId:long}/Author/Remove/{authorId:long}")]
	public async Task<IActionResult> Put([FromRoute] RemoveBookAuthor command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{bookId:long}/Publisher/Add/{publisherId:long}")]
	public async Task<IActionResult> Put([FromRoute] AddBookPublisher command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{bookId:long}/Publisher/Change/{publisherId:long}")]
	public async Task<IActionResult> Put([FromRoute] ChangeBookPublisher command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{bookId:long}/Publisher/Remove/{publisherId:long}")]
	public async Task<IActionResult> Put([FromRoute] RemoveBookPublisher command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpPut("{id:long}/Quantity")]
	public async Task<IActionResult> Put([FromRoute] long id, [FromBody] UpdateBookQuantity command)
	{
		command = command with { Id = id };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}
}
