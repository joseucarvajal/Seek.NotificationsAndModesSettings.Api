using Microsoft.VisualBasic.CompilerServices;
using System;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Queries
{
    public class GetModesByUserViewModel
    {
        public Guid IdMode { get; set; }
        public int ModeTypeId { get; set; }
        public string ModeTypeName { get; set; }
        public bool Active { get; set; }
    }
}
