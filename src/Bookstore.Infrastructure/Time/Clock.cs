using Bookstore.Shared.Abstractions.Services;

namespace Bookstore.Infrastructure.Time;
internal sealed class Clock : IClock
{
    public DateTime? Current() => DateTime.UtcNow;
}
