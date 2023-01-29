using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Users.Commands.GrantAdminRole;
public record GrantAdminRole(Guid Id) : ICommand;
