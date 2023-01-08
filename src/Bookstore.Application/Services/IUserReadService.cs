namespace Bookstore.Application.Services;
public interface IUserReadService
{
	Task<bool> ExistsByEmailAsync(string email);
	Task<bool> ExistsByUserNameAsync(string userName);
}
