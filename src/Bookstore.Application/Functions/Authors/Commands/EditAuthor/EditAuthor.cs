using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Authors.Commands.EditAuthor;
public record EditAuthor(Guid Id, string FullName) : ICommand;
