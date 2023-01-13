using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.UserCommands;
public record GrantAdminRole(Guid Id) : ICommand;
