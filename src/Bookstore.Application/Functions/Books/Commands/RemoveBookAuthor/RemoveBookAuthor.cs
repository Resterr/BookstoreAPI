using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Books.Commands.RemoveBookAuthor;
public record RemoveBookAuthor(Guid BookId, Guid AuthorId) : ICommand;
