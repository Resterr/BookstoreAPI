using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Users.Commands.UserPasswordChange;
public record UserPasswordChange(string Password, string ConfirmPassword) : ICommand;
