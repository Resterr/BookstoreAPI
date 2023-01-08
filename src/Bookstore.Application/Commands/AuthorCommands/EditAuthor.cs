using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.AuthorCommands;
public record EditAuthor(long Id, string FullName) : ICommand;
