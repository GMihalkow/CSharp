namespace MishMash.App.ViewModels.Users
{
    using MishMash.App.Models;
    using System.Collections.Generic;

    public class UserWithChannelsViewModel
    {
        public Role Role { get; set; }

        public ICollection<Channel> FollowedChannels { get; set; }

        public ICollection<Channel> SuggestedChannels { get; set; }

        public ICollection<Channel> SeeOtherChannels { get; set; }

        public ICollection<string> CommonTags { get; set; }
    }
}
