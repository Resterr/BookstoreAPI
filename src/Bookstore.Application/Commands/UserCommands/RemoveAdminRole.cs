using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.UserCommands;
public record RemoveAdminRole(long Id) : ICommand;
