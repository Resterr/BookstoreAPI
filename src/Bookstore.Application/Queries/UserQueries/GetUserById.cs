using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.UserQueries;
public class GetUserById : IQuery<UserDto>
{
	public long Id { get; set; }
}
