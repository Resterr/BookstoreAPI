using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.AuthorCommands;
public record RemoveAuthor(Guid Id) : ICommand;
