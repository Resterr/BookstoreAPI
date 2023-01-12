using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.BookCommands;
public record EditBook(long Id, string Name, double? Price, string CoverType,
	int? NumberOfPages, double? Height, double? Width) : ICommand;
