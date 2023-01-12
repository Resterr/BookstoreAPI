using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record UpdateBookQuantity(long Id, int Quantity) : ICommand;
