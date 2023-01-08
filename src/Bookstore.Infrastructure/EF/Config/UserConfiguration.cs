using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.EF.Config;
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(x => x.Id);

		builder
				.Property(x => x.Id)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.Email)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.Password)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.UserName)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.FullName)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.CreationDate)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();

		builder.ToTable("Users");
	}
}
