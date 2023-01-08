using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.EF.Config;
internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
	public void Configure(EntityTypeBuilder<Book> builder)
	{
		builder.HasKey(x => x.Id);

		builder
				.Property(x => x.Id)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.Name)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.Price)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.CoverType)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.NumberOfPages)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.Height)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.Width)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();
		builder
				.Property(x => x.Quantity)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();

		builder.ToTable("Books");
	}
}
