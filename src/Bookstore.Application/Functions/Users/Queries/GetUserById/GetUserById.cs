using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Functions.Users.Queries.GetUserById;
public class GetUserById : IQuery<UserDto>
{
	public Guid Id { get; set; }
}
