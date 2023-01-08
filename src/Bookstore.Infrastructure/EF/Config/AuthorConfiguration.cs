using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.EF.Config;
internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
	public void Configure(EntityTypeBuilder<Author> builder)
	{
		builder.HasKey(x => x.Id);

		builder
				.Property(x => x.Id)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();

		builder
				.Property(x => x.FullName)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();

		builder.ToTable("Authors");
	}
}
