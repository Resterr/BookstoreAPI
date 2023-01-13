using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.OrderCommands;
public record CreateOrder(Guid Id, IDictionary<Guid, int> booksIdWithQuantity) : ICommand;
