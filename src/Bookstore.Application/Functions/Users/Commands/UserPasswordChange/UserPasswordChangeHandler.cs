using Bookstore.Application.Exceptions.UserExceptions;
using Bookstore.Application.Security;
using Bookstore.Application.Services;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Application.Functions.Users.Commands.UserPasswordChange;
internal sealed class UserPasswordChangeHandler : ICommandHandler<UserPasswordChange>
{
	private readonly IUserRepository _repository;
	private readonly IPasswordManager _passwordManager;
	private readonly IUserContextService _userContext;

	public UserPasswordChangeHandler(IUserRepository repository, IPasswordManager passwordManager, IUserContextService userContext)
	{
		_repository = repository;
		_passwordManager = passwordManager;
		_userContext = userContext;
	}

	public async Task HandleAsync(UserPasswordChange command)
	{
		var userId = _userContext.GetUserId;

		var user = await _repository.GetByIdAsync(userId);

		if (user == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), userId.GetValueOrNull());
		}

		if (command.Password != command.ConfirmPassword)
		{
			throw new PasswordsNotMatchException();
		}

		var securedPassword = _passwordManager.Secure(command.Password);

		user.ChangePassword(securedPassword);

		await _repository.UpdateAsync(user);
	}
}
