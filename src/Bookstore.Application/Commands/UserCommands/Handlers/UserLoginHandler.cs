using Bookstore.Application.Exceptions.UserExceptions;
using Bookstore.Application.Security;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.UserCommands.Handlers;
internal sealed class UserLoginHandler : ICommandHandler<UserLogin>
{
	private readonly IUserRepository _repository;
	private readonly IAuthenticator _authenticator;
	private readonly IPasswordManager _passwordManager;
	private readonly ITokenStorage _tokenStorage;

	public UserLoginHandler(IUserRepository repository, IAuthenticator authenticator, IPasswordManager passwordManager,ITokenStorage tokenStorage)
	{
		_repository = repository;
		_authenticator = authenticator;
		_passwordManager = passwordManager;
		_tokenStorage = tokenStorage;
	}

	public async Task HandleAsync(UserLogin command)
	{
		var user = await _repository.GetByEmailAsync(command.Email);

		if (user is null)
		{
			throw new InvalidCredentialsException();
		}

		if (!_passwordManager.Validate(command.Password, user.Password))
		{
			throw new InvalidCredentialsException();
		}

		var jwt = _authenticator.CreateToken(user.Id, user.UserRole.Name.Value);
		_tokenStorage.Set(jwt);
	}
}
