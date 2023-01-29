using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Books.Commands.RemoveBookPublisher;
public record RemoveBookPublisher(Guid BookId) : ICommand;
