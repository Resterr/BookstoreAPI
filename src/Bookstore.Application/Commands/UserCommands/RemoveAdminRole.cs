using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.UserCommands;
public record RemoveAdminRole(Guid Id) : ICommand;
