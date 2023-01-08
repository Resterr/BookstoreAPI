using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record ChangeBookPublisher(long BookId, long PublisherId) : ICommand;
