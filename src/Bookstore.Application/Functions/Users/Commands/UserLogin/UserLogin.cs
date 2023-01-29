using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Users.Commands.UserLogin;
public record UserLogin(string Email, string Password) : ICommand;
