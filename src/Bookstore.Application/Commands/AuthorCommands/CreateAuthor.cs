using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.AuthorCommands;
public record CreateAuthor(long Id, string FullName) : ICommand;
