using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.PublisherCommands;
public record CreatePublisher(long Id, string Name) : ICommand;
