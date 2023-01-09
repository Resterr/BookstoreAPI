﻿using Bookstore.Application.Commands.PublisherCommands;
using Bookstore.Application.DTO;
using Bookstore.Application.Queries.PublisherQueries;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Queries;
using Bookstore.Shared.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

[Authorize(Policy = "is-admin")]
public class PublishersController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;
	private readonly IIdGeneratorService _idGenerator;

	public PublishersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IIdGeneratorService idGenerator)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
		_idGenerator = idGenerator;
	}

	[AllowAnonymous]
	[HttpGet("{id:long}")]
	public async Task<ActionResult<PublisherDto>> Get([FromRoute] GetPublisherById query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[AllowAnonymous]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<PublisherDto>>> Get([FromQuery] SearchPublishers query)
	{
		var result = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(result);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CreatePublisher command)
	{
		command = command with { Id = _idGenerator.Generate() };
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[HttpPut("{id:long}")]
	public async Task<IActionResult> Put([FromRoute] long id, [FromBody] EditPublisher command)
	{
		command = command with { Id = id };
		await _commandDispatcher.DispatchAsync(command);
		return Ok();
	}

	[HttpDelete("{id:long}")]
	public async Task<IActionResult> Delete([FromRoute] RemovePublisher command)
	{
		await _commandDispatcher.DispatchAsync(command);
		return NoContent();
	}
}