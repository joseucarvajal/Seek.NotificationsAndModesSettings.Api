using System;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Queries
{
    public class GetNotificationsByUserViewModel
    {
        public Guid IdNotification { get; set; }
        public int NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public bool Active { get; set; }
    }
}
