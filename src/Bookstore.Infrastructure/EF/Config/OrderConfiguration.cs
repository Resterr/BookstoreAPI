using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Config;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(x => x.Id);

		builder
				.Property(x => x.Id)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();

		builder
				.Property(x => x.CreationDate)
				.HasConversion(x => x.Value, x => new(x))
				.IsRequired();

		builder.ToTable("Orders");
	}
}
