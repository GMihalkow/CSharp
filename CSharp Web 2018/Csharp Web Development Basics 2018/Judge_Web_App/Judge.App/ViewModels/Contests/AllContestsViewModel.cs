namespace Judge.App.ViewModels.Contests
{
    using Judge.App.Models;

    public class AllContestsViewModel
    {
        public int SubmissionsCount { get; set; }

        public string ContestName { get; set; }

        public User ContestOwner { get; set; }
    }
}
