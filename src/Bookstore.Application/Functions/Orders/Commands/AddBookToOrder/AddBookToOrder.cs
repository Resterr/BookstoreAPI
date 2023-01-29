using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Orders.Commands.AddBookToOrder;
public record AddBookToOrder(Guid OrderId, Guid BookId, int Quantity) : ICommand;
