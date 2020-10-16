using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate;
using System;

namespace SeekQ.NotificationsAndModesSettings.Api.Infrastructure.EntityConfigurations
{
    public class UserModeTypeEntityConfiguration : IEntityTypeConfiguration<UserModeType>
    {
        public void Configure(EntityTypeBuilder<UserModeType> builder)
        {
            builder.ToTable("UserModeTypes");

            builder.HasKey(unt => unt.Id);

            builder.HasIndex(unt => new { unt.IdUser, unt.IdModeType }).IsUnique();

            builder.Property(unt => unt.Active)
                .IsRequired(true);

            builder.Property<int>("IdModeType")
                           .UsePropertyAccessMode(PropertyAccessMode.Field)
                           .HasColumnName("IdModeType")
                           .IsRequired(true);
            builder.HasOne(unt => unt.ModeType)
                .WithMany()
                .HasForeignKey("IdModeType");

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
