using App.Common.SeedWork;

namespace SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate
{
    public class NotificationType : Enumeration
    {
        public static NotificationType IncomingDiscreetHellos = new NotificationType(1, "Incoming discreet hello's");
        public static NotificationType IncomingGestures = new NotificationType(2, "Incoming gestures");
        public static NotificationType IncomingChat = new NotificationType(3, "Incoming chat");

        public NotificationType(int id, string name)
                   : base(id, name)
        {
        }
    }
}
