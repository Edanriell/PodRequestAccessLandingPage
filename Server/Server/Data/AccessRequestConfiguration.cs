using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Entities;

namespace Server.Data;

public class AccessRequestConfiguration : IEntityTypeConfiguration<AccessRequest>
{
	public void Configure(EntityTypeBuilder<AccessRequest> builder)
	{
		builder.ToTable("AccessRequests");
		builder.HasKey(a => a.Id);
		builder.Property(a => a.Id)
		       .HasColumnName(nameof(AccessRequest.Id))
		       .HasColumnType("uuid")
		       .HasDefaultValueSql("uuid_generate_v4()");
		builder.Property(a => a.Email)
		       .HasColumnName(nameof(AccessRequest.Email))
		       .HasColumnType("varchar")
		       .HasMaxLength(150)
		       .IsRequired();
	}
}