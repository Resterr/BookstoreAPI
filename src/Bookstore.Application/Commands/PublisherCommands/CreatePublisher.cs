using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.PublisherCommands;
public record CreatePublisher(Guid Id, string Name) : ICommand;
