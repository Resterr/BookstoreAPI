using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.PublisherValueObjects;

namespace Bookstore.Domain.Repositories;
public interface IPublisherRepository
{
	Task<Publisher> GetAsync(PublisherId id);
	Task AddAsync(Publisher publisher);
	Task UpdateAsync(Publisher publisher);
	Task DeleteAsync(Publisher publisher);
}
