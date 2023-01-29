using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Publishers.Commands.RemovePublisher;
public record RemovePublisher(Guid Id) : ICommand;
