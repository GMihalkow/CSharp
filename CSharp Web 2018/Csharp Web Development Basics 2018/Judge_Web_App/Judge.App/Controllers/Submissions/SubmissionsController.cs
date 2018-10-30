namespace Judge.App.Controllers.Submissions
{
    using Judge.App.Models;
    using Judge.App.ViewModels.Submissions;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;

    public class SubmissionsController : BaseController
    {
        [Authorize]
        public IHttpResponse All()
        {
            var contests = this.DbContext.Contests.Include(c => c.Submissions).ToArray();
            return this.View(contests);
        }
        
        [Authorize]
        public IHttpResponse Create()
        {
            var contests = this.DbContext.Contests.ToArray();
            return this.View(contests);
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Create(PostSubmissionViewModel model)
        {
            var user = this.DbContext.Users.FirstOrDefault(u => u.FullName == this.User.Username);
            if (user == null)
                return this.BadRequestError("User doesn't exist!");

            var contest = this.DbContext.Contests.Where(c => c.Name == model.ContestName).FirstOrDefault();
            if (contest == null)
                return this.BadRequestError("Contest doesn't exist!");

            int buildSuccessChance = new Random().Next(0, 100);

            Submission submission = model.To<Submission>();
            submission.UserId = user.Id;
            submission.ContestId = contest.Id;
            if (buildSuccessChance >= 70)
                submission.Build = "Build Success";
            else
                submission.Build = "Build Failed";

            this.DbContext.Submissions.Add(submission);
            this.DbContext.SaveChanges();

            return this.Redirect("/Submissions/All");
        }
    }
}