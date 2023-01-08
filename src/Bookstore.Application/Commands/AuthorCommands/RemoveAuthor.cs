using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.AuthorCommands;
public record RemoveAuthor(long Id) : ICommand;
