using System.Collections.Generic;
using Following = Gighub.Models.Following;

namespace Gighub.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<Following> FollowedArtist { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}