using Bookstore.Application.DTO;
using Bookstore.Domain.Entities;

namespace Bookstore.Infrastructure.EF.Queries;
internal static class Extensions
{
	public static BookDto AsDto(this Book model) => new()
	{
		Id = model.Id.Value,
		Name = model.Name.Value,
		Price = model.Price.Value,
		CoverType = model.CoverType.Value,
		NumberOfPages = model.NumberOfPages.Value,
		Size = string.Concat(model.Height.Value.ToString(), "x", model.Width.Value.ToString()),
		Quantity = model.Quantity.Value,
		Authors = from i in model.Authors
				  select i.Author.AsDto(),
		Publisher = model.Publisher?.AsDto(),
	};

	public static AuthorDto AsDto(this Author model) => new()
	{
		Id = model.Id.Value,
		FullName = model.FullName.Value,
	};

	public static PublisherDto AsDto(this Publisher model) => new()
	{
		Id = model.Id.Value,
		Name = model.Name.Value,
	};

	public static UserDto AsDto(this User model) => new()
	{
		Id = model.Id.Value,
		Email = model.Email.Value,
		UserName = model.UserName.Value,
		FullName = model.FullName.Value,
		RoleName = model.UserRole?.Name.Value,
	};

	public static OrderDto AsDto(this Order model) => new()
	{
		Id = model.Id.Value,
		CreatedBy = model.CreatedBy?.AsDto(),
		OrderStatus = Enum.GetName(model.OrderStatus),
		CreationDate = model.CreationDate.Value,
		Books = from i in model.Books
				select i.Book.AsDto(i.Quantity),
	};

	public static BookDto AsDto(this Book model, int orderBookQuantity) => new()
	{
		Id = model.Id.Value,
		Name = model.Name.Value,
		Price = model.Price.Value,
		CoverType = model.CoverType.Value,
		NumberOfPages = model.NumberOfPages.Value,
		Size = string.Concat(model.Height.Value.ToString(), "x", model.Width.Value.ToString()),
		Quantity = orderBookQuantity,
		Authors = from i in model.Authors
				  select i.Author.AsDto(),
		Publisher = model.Publisher?.AsDto(),
	};
}

