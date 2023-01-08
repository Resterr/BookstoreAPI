using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.PublisherCommands;
public record EditPublisher(long Id, string Name) : ICommand;
