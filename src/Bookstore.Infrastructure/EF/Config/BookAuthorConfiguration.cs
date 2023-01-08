using Bookstore.Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.EF.Config;
internal sealed class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
	public void Configure(EntityTypeBuilder<BookAuthor> builder)
	{
		builder
			.HasKey(x => new { x.BookId, x.AuthorId });

		builder
			.HasOne(pt => pt.Book)
			.WithMany(p => p.Authors)
			.HasForeignKey(pt => pt.BookId);

		builder
			.HasOne(pt => pt.Author)
			.WithMany(t => t.Books)
			.HasForeignKey(pt => pt.AuthorId);

		builder.ToTable("BookAuthors");
	}
}
