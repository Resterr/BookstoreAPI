using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Orders.Commands.ChangeStatus;
public record ChangeStatus(Guid Id, string StatusName) : ICommand;
