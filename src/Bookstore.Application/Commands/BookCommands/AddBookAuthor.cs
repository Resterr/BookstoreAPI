using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record AddBookAuthor(long BookId, long AuthorId) : ICommand;
