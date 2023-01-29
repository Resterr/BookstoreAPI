using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Books.Commands.CreateBook;
public record CreateBook(Guid Id, string Name, double Price, string CoverType,
	int NumberOfPages, double Height, double Width, int Quantity) : ICommand;
