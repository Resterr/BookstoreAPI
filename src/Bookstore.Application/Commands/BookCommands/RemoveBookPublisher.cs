using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record RemoveBookPublisher(Guid BookId, Guid PublisherId) : ICommand;
