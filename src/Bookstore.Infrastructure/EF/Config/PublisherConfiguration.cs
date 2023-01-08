using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Config;
internal sealed class PublisherConfiguratiom : IEntityTypeConfiguration<Publisher>
{
	public void Configure(EntityTypeBuilder<Publisher> builder)
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

		builder.ToTable("Publishers");
	}
}
