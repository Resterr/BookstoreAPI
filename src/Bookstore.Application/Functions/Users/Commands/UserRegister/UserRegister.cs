using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Users.Commands.UserRegister;
public record UserRegister(Guid Id, string Email, string Password, string ConfirmPassword, string UserName, string FullName) : ICommand;
