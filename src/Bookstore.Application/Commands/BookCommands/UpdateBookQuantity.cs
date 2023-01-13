using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record UpdateBookQuantity(Guid Id, int Quantity) : ICommand;
