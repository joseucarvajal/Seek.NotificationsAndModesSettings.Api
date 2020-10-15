using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate;
using System;

namespace SeekQ.NotificationsAndModesSettings.Api.Infrastructure.EntityConfigurations
{
    public class UserNotificationTypeEntityConfiguration : IEntityTypeConfiguration<UserNotificationType>
    {
        public void Configure(EntityTypeBuilder<UserNotificationType> builder)
        {
            builder.ToTable("UserNotificationTypes");
            
            builder.HasKey(unt => unt.Id);

            builder.HasIndex(unt => new { unt.IdUser, unt.IdNotificationType }).IsUnique();

            builder.Property(unt => unt.Active)
                .IsRequired(true);

            builder.Property<int>("IdNotificationType")
                           .UsePropertyAccessMode(PropertyAccessMode.Field)
                           .HasColumnName("IdNotificationType")
                           .IsRequired(true);
            builder.HasOne(unt => unt.NotificationType)
                .WithMany()
                .HasForeignKey("IdNotificationType");

            builder.Property<Guid>("IdUser")
                           .UsePropertyAccessMode(PropertyAccessMode.Field)
                           .HasColumnName("IdUser")
                           .IsRequired(true);
            builder.HasOne(unt => unt.User)
                .WithMany()
                .HasForeignKey("IdUser");

        }
    }
}
