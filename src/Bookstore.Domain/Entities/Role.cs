using Bookstore.Domain.ValueObjects.RoleValueObjects;

namespace Bookstore.Domain.Entities;
public class Role
{
	public RoleId Id { get; set; }
	public RoleName Name { get; private set; }

	private Role() { }

	public Role(RoleId id, RoleName name)
	{
		Id = id;
		Name = name;
	}
}
