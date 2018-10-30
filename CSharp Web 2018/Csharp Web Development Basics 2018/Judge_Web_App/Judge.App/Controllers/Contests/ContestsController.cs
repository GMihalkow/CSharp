namespace Judge.App.Controllers.Contests
{
    using Judge.App.Models;
    using Judge.App.ViewModels.Contests;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class ContestsController : BaseController
    {
        [Authorize]
        public IHttpResponse All()
        {
            var contests =
                this.DbContext
                .Contests
                .Select(c => new AllContestsViewModel()
                {
                    Id = c.Id,
                    ContestName = c.Name,
                    SubmissionsCount = c.Submissions.Count,
                    ContestOwner = c.Users.FirstOrDefault().User ?? new Models.User() { FullName = string.Empty}
                })
                .ToArray();

            return this.View(contests);
        }

        [Authorize]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Create(PostContestViewModel model)
        {
            if (this.DbContext.Contests.Any(c => c.Name == model.Name))
                return this.BadRequestErrorWithView("This contest already exists!");

            var user = this.DbContext.Users.FirstOrDefault(u => u.FullName == this.User.Username);

            Contest contest = model.To<Contest>();
            this.DbContext.Contests.Add(contest);
            this.DbContext.SaveChanges();

            UserContest userContest = new UserContest()
            {
                UserId = user.Id,
                ContestId = this.DbContext.Contests.First(c => c.Name == contest.Name).Id
            };
            this.DbContext.UserContests.Add(userContest);
            this.DbContext.SaveChanges();

            return this.Redirect("/Contests/All");
        }

        [Authorize]
        public IHttpResponse Edit(int Id)
        {
            var contest = this.DbContext.Contests.First(c => c.Id == Id);
            return this.View(contest);
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Edit(int Id, PostContestViewModel model)
        {
            var contest = this.DbContext.Contests.Where(c => c.Id == Id).FirstOrDefault();
            if (contest == null)
                return this.BadRequestError("Contest doesn't exist!");

            if (this.DbContext.Contests.Any(c => c.Name == model.Name))
                return this.BadRequestErrorWithView("This contest already exists!", contest);

            contest.Name = model.Name;


            this.DbContext.Entry(contest).State = EntityState.Modified;
            this.DbContext.SaveChanges();

            return this.Redirect("/Contests/All");
        }

        [Authorize]
        public IHttpResponse Delete(int Id)
        {
            var contest = this.DbContext.Contests.FirstOrDefault(c => c.Id == Id);
            if (contest == null)
                return this.BadRequestError("Contest doesn't exist!");

            return this.View(contest);
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Delete(int Id, PostContestViewModel model)
        {
            var contest = this.DbContext.Contests.FirstOrDefault(c => c.Id == Id);
            if (contest == null)
                return this.BadRequestError("Contest doesn't exist!");

            this.DbContext.Contests.Remove(contest).State = EntityState.Deleted;
            this.DbContext.SaveChanges();

            return this.Redirect("/Contests/All");
        }
    }
}