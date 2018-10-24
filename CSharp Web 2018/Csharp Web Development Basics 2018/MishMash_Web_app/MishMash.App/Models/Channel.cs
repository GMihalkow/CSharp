namespace MishMash.App.Models
{
    using System.Collections.Generic;

    public class Channel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType Type { get; set; }

        public ICollection<ChannelTag> Tags { get; set; }

        public ICollection<UserChannel> Followers { get; set; }
    }
}