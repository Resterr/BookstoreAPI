using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Books.Commands.AddBookPublisher;
public record AddBookPublisher(Guid BookId, Guid PublisherId) : ICommand;
