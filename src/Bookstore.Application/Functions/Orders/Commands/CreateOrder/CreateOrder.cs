using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Orders.Commands.CreateOrder;
public record CreateOrder(Guid Id, IDictionary<Guid, int> booksIdWithQuantity) : ICommand;
