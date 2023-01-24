using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Users.Commands.RemoveAdminRole;
public record RemoveAdminRole(Guid Id) : ICommand;
