using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.AuthorCommands;
public record CreateAuthor(Guid Id, string FullName) : ICommand;
