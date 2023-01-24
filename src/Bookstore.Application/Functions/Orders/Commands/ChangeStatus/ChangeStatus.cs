using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Consts;

namespace Bookstore.Application.Functions.Orders.Commands.ChangeStatus;
public record ChangeStatus(Guid Id, OrderStatus orderStatus) : ICommand;
