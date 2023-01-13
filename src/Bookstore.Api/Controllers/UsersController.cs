using Bookstore.Application.Commands.UserCommands;
using Bookstore.Application.DTO;
using Bookstore.Application.Queries.UserQueries;
using Bookstore.Application.Security;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers;

[Authorize]
public class UsersController : BaseController
{
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;
	private readonly ITokenStorage _tokenStorage;

	public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ITokenStorage tokenStorage)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
		_tokenStorage = tokenStorage;
	}

	[Authorize(Policy = "is-admin")]
	[HttpGet("{id:Guid}")]
	public async Task<ActionResult<UserDto>> Get([FromRoute] GetUserById query)
	{
		var user = await _queryDispatcher.QueryAsync(query);
		return OkOrNotFound(user);
	}

	[AllowAnonymous]
	[HttpPost("register")]
	public async Task<IActionResult> Post([FromBody] UserRegister command)
	{
		command = command with { Id = Guid.NewGuid() };
		await _commandDispatcher.DispatchAsync(command);
		return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
	}

	[AllowAnonymous]
	[HttpPost("login")]
	public async Task<ActionResult<JwtDto>> Post([FromBody] UserLogin command)
	{
		await _commandDispatcher.DispatchAsync(command);

		var jwt = _tokenStorage.Get();
		return jwt;
	}

	[HttpPut("update/password")]
	public async Task<IActionResult> Put([FromBody] UserPasswordChange command)
	{
		await _commandDispatcher.DispatchAsync(command);

		return Ok();
	}

	[Authorize(Policy = "is-superadmin")]
	[HttpPut("{id:Guid}/role/grant/admin")]
	public async Task<IActionResult> Put([FromRoute] GrantAdminRole command)
	{
		await _commandDispatcher.DispatchAsync(command);

		return Ok();
	}


	[Authorize(Policy = "is-superadmin")]
	[HttpPut("{id:Guid}/role/remove/admin")]
	public async Task<IActionResult> Put([FromRoute] RemoveAdminRole command)
	{
		await _commandDispatcher.DispatchAsync(command);

		return Ok();
	}
}
