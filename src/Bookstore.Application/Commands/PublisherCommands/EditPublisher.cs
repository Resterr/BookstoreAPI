using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.PublisherCommands;
public record EditPublisher(Guid Id, string Name) : ICommand;
