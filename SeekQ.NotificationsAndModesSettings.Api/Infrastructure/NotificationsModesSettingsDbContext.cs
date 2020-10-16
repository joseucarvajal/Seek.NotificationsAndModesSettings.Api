using Microsoft.EntityFrameworkCore;
using SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Domain.UserAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Infrastructure.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Infrastructure
{
    public class NotificationsModesSettingsDbContext : DbContext
    {
        public NotificationsModesSettingsDbContext(DbContextOptions<NotificationsModesSettingsDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<UserNotificationType> UserNotificationTypes { get; set; }
        public DbSet<ModeType> ModeTypes { get; set; }
        public DbSet<UserModeType> UserModeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserNotificationTypeEntityConfiguration());
        }
    }
}
