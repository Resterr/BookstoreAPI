using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Entities.Relations;

namespace Bookstore.Infrastructure.EF.Config;
public class OrderBookConfiguration : IEntityTypeConfiguration<OrderBook>
{
	public void Configure(EntityTypeBuilder<OrderBook> builder)
	{
		builder
			.HasKey(x => new { x.OrderId, x.BookId });

		builder
			.HasOne(pt => pt.Order)
			.WithMany(p => p.Books)
			.HasForeignKey(pt => pt.OrderId);

		builder
			.HasOne(pt => pt.Book)
			.WithMany(t => t.Orders)
			.HasForeignKey(pt => pt.BookId);

		builder
		.Property(x => x.Quantity)
		.HasConversion(x => x.Value, x => new(x))
		.IsRequired();

		builder.ToTable("OrderBooks");
	}
}
