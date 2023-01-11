using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.OrderCommands;
public record CreateOrder(long Id, IDictionary<long, int> booksIdWithQuantity) : ICommand;
