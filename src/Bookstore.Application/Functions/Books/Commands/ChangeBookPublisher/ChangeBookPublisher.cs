using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Books.Commands.ChangeBookPublisher;
public record ChangeBookPublisher(Guid BookId, Guid PublisherId) : ICommand;
