namespace Judge.App.Models
{
    using System.Collections.Generic;

    public class Contest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Submission> Submissions { get; set; }

        public ICollection<UserContest> Users { get; set; }
    }
}