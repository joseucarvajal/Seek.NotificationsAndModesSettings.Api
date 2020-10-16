using App.Common.SeedWork;

namespace SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate
{
    public class NotificationType : Enumeration
    {
        public static NotificationType IncomingDiscreetHellos = new NotificationType(1, "Incoming discreet hello's");
        public static NotificationType IncomingGestures = new NotificationType(2, "Incoming gestures");
        public static NotificationType IncomingChat = new NotificationType(3, "Incoming chat");
        public static NotificationType TemperatureMeterChange = new NotificationType(4, "Temperature meter change");
        public static NotificationType InAppVibrations = new NotificationType(5, "In app vibrations");
        public static NotificationType InAppSounds = new NotificationType(6, "In app sounds");

        public NotificationType(int id, string name)
                   : base(id, name)
        {
        }
    }
}
