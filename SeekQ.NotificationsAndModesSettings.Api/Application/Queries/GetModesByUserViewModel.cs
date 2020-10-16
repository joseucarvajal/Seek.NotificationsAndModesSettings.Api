using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Queries
{
    public class GetModesByUserViewModel
    {
        public Guid IdMode { get; set; }
        public string ModeName { get; set; }
        public bool Active { get; set; }
    }
}
