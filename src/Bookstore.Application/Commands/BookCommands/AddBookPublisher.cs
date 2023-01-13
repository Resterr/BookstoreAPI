using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record AddBookPublisher(Guid BookId, Guid PublisherId) : ICommand;
