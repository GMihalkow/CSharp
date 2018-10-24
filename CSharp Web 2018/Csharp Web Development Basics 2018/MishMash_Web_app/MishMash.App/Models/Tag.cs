namespace MishMash.App.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public ICollection<ChannelTag> Channels { get; set; }
    }
}