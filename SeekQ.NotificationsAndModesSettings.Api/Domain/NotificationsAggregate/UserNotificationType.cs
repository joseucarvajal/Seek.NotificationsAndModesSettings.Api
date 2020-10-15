using App.Common.Repository;
using SeekQ.NotificationsAndModesSettings.Api.Domain.UserAggregate;
using System;

namespace SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate
{
    public class UserNotificationType : BaseEntity
    {
        public int IdNotificationType { get; set; }
        public NotificationType NotificationType { get; set; }

        public Guid IdUser { get; set; }
        public User User { get; set; }

        public bool Active { get; set; }
    }
}
