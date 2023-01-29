using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Authors.Commands.RemoveAuthor;
public record RemoveAuthor(Guid Id) : ICommand;
