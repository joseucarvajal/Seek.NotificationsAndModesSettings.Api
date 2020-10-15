using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate;

namespace SeekQ.NotificationsAndModesSettings.Api.Infrastructure.EntityConfigurations
{
    public class NotificationTypeEntityConfiguration : IEntityTypeConfiguration<NotificationType>
    {
        public void Configure(EntityTypeBuilder<NotificationType> builder)
        {
            builder.ToTable("NotificationTypes");
            
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
