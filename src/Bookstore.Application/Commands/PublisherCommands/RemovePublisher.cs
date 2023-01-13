using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.PublisherCommands;
public record RemovePublisher(Guid Id) : ICommand;
