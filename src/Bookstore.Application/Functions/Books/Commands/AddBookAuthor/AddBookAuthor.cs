using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Books.Commands.AddBookAuthor;
public record AddBookAuthor(Guid BookId, Guid AuthorId) : ICommand;
