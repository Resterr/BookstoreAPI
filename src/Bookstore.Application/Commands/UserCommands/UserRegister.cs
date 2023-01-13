using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.UserCommands;
public record UserRegister(Guid Id, string Email, string Password, string ConfirmPassword, string UserName, string FullName) : ICommand;
