namespace Judge.App.ViewModels.Contests
{
    using Judge.App.Models;
    using System.Collections.Generic;

    public class AllContestsViewModel
    {
        public int Id { get; set; }

        public int SubmissionsCount { get; set; }

        public string ContestName { get; set; }

        public User ContestOwner { get; set; }
    }
}
