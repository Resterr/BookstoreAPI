using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Books.Commands.UpdateBookQuantity;
public record UpdateBookQuantity(Guid Id, int Quantity) : ICommand;
