using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Orders.Commands.RemoveBookFromOrder;
public record RemoveBookFromOrder(Guid OrderId, Guid BookId) : ICommand;
