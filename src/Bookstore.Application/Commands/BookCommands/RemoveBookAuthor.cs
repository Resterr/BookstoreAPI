using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record RemoveBookAuthor(Guid BookId, Guid AuthorId) : ICommand;
