using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record AddBookPublisher(long BookId, long PublisherId) : ICommand;
