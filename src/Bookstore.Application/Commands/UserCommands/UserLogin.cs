using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.UserCommands;
public record UserLogin(string Email, string Password) : ICommand;
