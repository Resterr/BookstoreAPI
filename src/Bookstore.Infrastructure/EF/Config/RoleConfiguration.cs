using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastructure.EF.Config;
internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
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

		builder.ToTable("Roles");
	}
}
