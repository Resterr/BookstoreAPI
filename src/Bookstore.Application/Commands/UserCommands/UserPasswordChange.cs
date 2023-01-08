using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.UserCommands;
public record UserPasswordChange(string Password, string ConfirmPassword) : ICommand;
