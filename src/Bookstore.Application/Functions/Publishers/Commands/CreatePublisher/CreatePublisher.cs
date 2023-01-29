using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Publishers.Commands.CreatePublisher;
public record CreatePublisher(Guid Id, string Name) : ICommand;
