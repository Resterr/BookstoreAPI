using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record RemoveBookPublisher(long BookId, long PublisherId) : ICommand;
