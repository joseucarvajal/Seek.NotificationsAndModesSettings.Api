using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Domain.UserAggregate;
using System;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Infrastructure
{
    public class NotificationsModesSettingsSeeding
    {
        public static readonly Guid ID_USER_JOSE = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D7");
        public static readonly Guid ID_USER_DANIEL = new Guid("545DE66E-19AC-47D2-57F6-08D8715337D9");

        public async Task SeedAsync(NotificationsModesSettingsDbContext context, IServiceProvider services)
        {
            // Get a logger
            var logger = services.GetRequiredService<ILogger<NotificationsModesSettingsSeeding>>();

            context.Database.EnsureCreated();

            if (await context.UserNotificationTypes.AnyAsync())
            {
                return;
            }

            //Add notification types
            context.NotificationTypes.Add(NotificationType.IncomingDiscreetHellos);
            context.NotificationTypes.Add(NotificationType.IncomingGestures);
            context.NotificationTypes.Add(NotificationType.IncomingChat);

            //Add users
            User userJose = new User
            {
                Id = ID_USER_JOSE
            };
            context.Users.Add(userJose);

            User userDaniel = new User
            {
                Id = ID_USER_DANIEL
            };
            context.Users.Add(userDaniel);

            //Add user-notification-types
            context.UserNotificationTypes.Add(new UserNotificationType { 
                User = userJose,
                NotificationType = NotificationType.IncomingChat,
                Active = true
            });
            context.UserNotificationTypes.Add(new UserNotificationType
            {
                User = userJose,
                NotificationType = NotificationType.IncomingGestures,
                Active = true
            });

            context.UserNotificationTypes.Add(new UserNotificationType
            {
                User = userDaniel,
                NotificationType = NotificationType.IncomingChat,
                Active = false
            });

            await context.SaveChangesAsync();
        }
    }
}
