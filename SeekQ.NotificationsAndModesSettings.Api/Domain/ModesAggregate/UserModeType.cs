using App.Common.Repository;
using SeekQ.NotificationsAndModesSettings.Api.Domain.UserAggregate;
using System;

namespace SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate
{
    public class UserModeType : BaseEntity
    {
        public int IdModeType { get; set; }
        public ModeType ModeType { get; set; }

        public Guid IdUser { get; set; }
        public User User { get; set; }

        public bool Active { get; set; }
    }
}
