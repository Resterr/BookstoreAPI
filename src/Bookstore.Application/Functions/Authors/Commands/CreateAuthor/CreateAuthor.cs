using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Authors.Commands.CreateAuthor;
public record CreateAuthor(Guid Id, string FullName) : ICommand;
