using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Books.Commands.RemoveBook;
public record RemoveBook(Guid Id) : ICommand;
