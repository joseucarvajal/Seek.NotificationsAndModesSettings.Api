using App.Common.SeedWork;

namespace SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate
{
    public class ModeType : Enumeration
    {
        public static ModeType ReceptivityMode = new ModeType(1, "Receptivity mode");
        public static ModeType IncognitoMode = new ModeType(2, "Incognito mode");

        public ModeType(int id, string name)
                   : base(id, name)
        {
        }
    }
}
