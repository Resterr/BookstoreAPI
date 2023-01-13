using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record AddBookAuthor(Guid BookId, Guid AuthorId) : ICommand;
