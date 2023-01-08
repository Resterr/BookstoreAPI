using Bookstore.Domain.Events.UserEvents;
using Bookstore.Domain.ValueObjects.UserValueObjects;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Entities;
public class User : AggregateRoot<UserId>
{
	public new UserId Id { get; private set; }
	public UserEmail Email { get; private set; }
	public UserPassword Password { get; private set; }
	public UserName UserName { get; private set; }
	public UserFullName FullName { get; private set; }
	public UserCreationDate CreationDate { get; set; }
	public Role UserRole { get; private set; }

	private User() { }

	public User(UserId id, UserEmail email, UserPassword password, UserName userName, UserFullName fullName, UserCreationDate creationDate, Role role)
	{
		Id = id;
		Email = email;
		Password = password;
		UserName = userName;
		FullName = fullName;
		CreationDate = creationDate;
		UserRole = role;
	}

	public void UpdateUserInfo(UserName userName, UserFullName fullName)
	{
		UserName = userName;
		FullName = fullName;

		AddEvent(new UserInfoUpdated(this));
	}

	public void ChangePassword(UserPassword password)
	{
		Password = password;

		AddEvent(new UserPasswordUpdated(this));
	}

	public void ChangeRole(Role role)
	{
		UserRole = role;

		AddEvent(new UserRoleUpdated(this, role));
	}
}
