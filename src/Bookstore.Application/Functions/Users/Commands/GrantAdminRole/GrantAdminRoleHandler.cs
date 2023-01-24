using Bookstore.Application.Services;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Users.Commands.GrantAdminRole;
internal sealed class GrantAdminRoleHandler : ICommandHandler<GrantAdminRole>
{
	private readonly IUserRepository _repository;
	private readonly IRoleReadService _roleReadService;

	public GrantAdminRoleHandler(IUserRepository repository, IRoleReadService roleReadService)
	{
		_repository = repository;
		_roleReadService = roleReadService;
	}

	public async Task HandleAsync(GrantAdminRole command)
	{
		var adminRole = await _roleReadService.AdminRole();

		var user = await _repository.GetByIdAsync(command.Id);

		if (user == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		user.ChangeRole(adminRole);

		await _repository.UpdateAsync(user);
	}
}
