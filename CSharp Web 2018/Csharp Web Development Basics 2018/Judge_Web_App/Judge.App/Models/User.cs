namespace Judge.App.Models
{
    using Judge.App.Models.Enums;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public Role Role { get; set; }

        public ICollection<UserContest> Contests { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}