using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate;

namespace SeekQ.NotificationsAndModesSettings.Api.Infrastructure.EntityConfigurations
{
    public class ModeTypeEntityConfiguration : IEntityTypeConfiguration<ModeType>
    {
        public void Configure(EntityTypeBuilder<ModeType> builder)
        {
            builder.ToTable("ModeTypes");

            builder.HasKey(u => u.Id);

            builder.HasIndex(nt => nt.Name).IsUnique();

            builder.Property(g => g.Id)
                            .ValueGeneratedNever()
                            .IsRequired();

            builder.Property(g => g.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
