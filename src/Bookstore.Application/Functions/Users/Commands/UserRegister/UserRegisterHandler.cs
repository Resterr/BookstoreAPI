using Bookstore.Application.Exceptions.UserExceptions;
using Bookstore.Application.Security;
using Bookstore.Application.Services;
using Bookstore.Domain.Factories.Abstractions;
using Bookstore.Domain.Repositories;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Services;

namespace Bookstore.Application.Functions.Users.Commands.UserRegister;
internal sealed class UserRegisterHandler : ICommandHandler<UserRegister>
{
	private readonly IUserFactory _factory;
	private readonly IUserRepository _repository;
	private readonly IUserReadService _readService;
	private readonly IPasswordManager _passwordManager;
	private readonly IClock _clock;
	private readonly IRoleReadService _roleReadService;

	public UserRegisterHandler(IUserFactory factory, IUserRepository repository, IUserReadService readService, IPasswordManager passwordManager, IClock clock, IRoleReadService roleReadService)
	{
		_factory = factory;
		_repository = repository;
		_readService = readService;
		_passwordManager = passwordManager;
		_clock = clock;
		_roleReadService = roleReadService;
	}

	public async Task HandleAsync(UserRegister command)
	{
		if (await _readService.ExistsByEmailAsync(command.Email))
		{
			throw new EmailAlreadyInUseException(command.Email);
		}

		if (await _readService.ExistsByUserNameAsync(command.UserName))
		{
			throw new UserNameAlreadyInUseException(command.UserName);
		}

		if (command.Password != command.ConfirmPassword)
		{
			throw new PasswordsNotMatchException();
		}

		var securedPassword = _passwordManager.Secure(command.Password);
		var creationDate = _clock.Current();
		var defaultRole = await _roleReadService.DefaultRole();

		var user = _factory.Create(command.Id, command.Email, securedPassword, command.UserName, command.FullName, creationDate, defaultRole);
		await _repository.AddAsync(user);
	}
}
