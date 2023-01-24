using Bookstore.Application.Services;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Users.Commands.RemoveAdminRole;
internal sealed class RemoveAdminRoleHandler : ICommandHandler<RemoveAdminRole>
{
	private readonly IUserRepository _repository;
	private readonly IRoleReadService _roleReadService;

	public RemoveAdminRoleHandler(IUserRepository repository, IRoleReadService roleReadService)
	{
		_repository = repository;
		_roleReadService = roleReadService;
	}

	public async Task HandleAsync(RemoveAdminRole command)
	{
		var defaultRole = await _roleReadService.DefaultRole();

		var user = await _repository.GetByIdAsync(command.Id);

		if (user == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), command.Id);
		}

		user.ChangeRole(defaultRole);

		await _repository.UpdateAsync(user);
	}
}
