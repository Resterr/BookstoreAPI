using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Publishers.Commands.EditPublisher;
public record EditPublisher(Guid Id, string Name) : ICommand;
