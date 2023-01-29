using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Orders.Commands.ChangeBookQuantity;
public record ChangeBookQuantity(Guid OrderId, Guid BookId, int Quantity) : ICommand;
