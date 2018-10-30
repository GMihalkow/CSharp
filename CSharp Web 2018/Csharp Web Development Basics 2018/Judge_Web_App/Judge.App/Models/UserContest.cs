namespace Judge.App.Models
{
    public class UserContest
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ContestId { get; set; }

        public Contest Contest { get; set; }
    }
}