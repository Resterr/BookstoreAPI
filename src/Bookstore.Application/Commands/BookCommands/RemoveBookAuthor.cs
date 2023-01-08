using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record RemoveBookAuthor(long BookId, long AuthorId) : ICommand;
