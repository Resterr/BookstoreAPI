using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.AuthorCommands;
public record EditAuthor(Guid Id, string FullName) : ICommand;
