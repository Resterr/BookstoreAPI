using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record ChangeBookPublisher(Guid BookId, Guid PublisherId) : ICommand;
