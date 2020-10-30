using System;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Queries
{
    public class GetNotificationsByUserViewModel
    {
        public Guid IdNotification { get; set; }        
        public string NotificationName { get; set; }
        public bool Active { get; set; }
    }
}
