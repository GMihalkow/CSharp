namespace Torshia.App.Controllers.Tasks
{
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;
    using Torshia.App.Models;
    using Torshia.App.Models.Enums;
    using Torshia.App.ViewModels.Tasks;

    public class TasksController : BaseController
    {
        [Authorize]
        public IHttpResponse Create()
        {
            if (this.User.Role != "Admin")
            {
                return this.BadRequestError("404 Page Not Found");
            }

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Create(PostTaskViewModel model)
        {
            var tempSectors = new string[]
            {
                model.Marketing,
                model.Customers,
                model.Internal,
                model.Finances,
                model.Management
            };
            tempSectors = tempSectors.Where(s => s != null).ToArray();

            Task task = model.To<Task>();
            if (this.DbContext.Tasks.Any(t => t.Title == task.Title))
            {
                return this.BadRequestErrorWithView("Task already exists!");
            }

            this.DbContext.Add(task);
            this.DbContext.SaveChanges();

            foreach (var sector in tempSectors)
            {
                Sector newSector = null;

                if (this.DbContext.Sectors.Any(s => s.SectorType == (SectorType)Enum.Parse(typeof(SectorType), sector)))
                {
                    newSector = this.DbContext.Sectors.First(s => s.SectorType == (SectorType)Enum.Parse(typeof(SectorType), sector));
                }
                else
                {
                    newSector = new Sector()
                    {
                        SectorType = (SectorType)Enum.Parse(typeof(SectorType), sector)
                    };

                    this.DbContext.Add(newSector);
                    this.DbContext.SaveChanges();

                }

                TaskSector taskSector = new TaskSector()
                {
                    TaskId = task.Id,
                    SectorId = newSector.Id
                };

                this.DbContext.Add(taskSector);
                this.DbContext.SaveChanges();
            }

            return this.Redirect($"/Tasks/Details?Id={task.Id}");
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {
            var taskExists =
                this.DbContext
                .Tasks.Any(t => t.Id == id);

            if (taskExists == false)
                return this.BadRequestError("Task doesn't exist");

            TaskDetailsViewModel viewModel =
                this.DbContext
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Title = t.Title,
                    Level = t.AffectedSectors.Count,
                    Description = t.Description,
                    DueDate = t.DueDate.ToString("d"),
                    AffectedSectors = string.Join(", ", t.AffectedSectors.Select(a => a.Sector.SectorType.ToString())),
                    Participants = string.Join(", ", t.Participants.Select(p => p.Participant.Name))
                })
                .First();

            return this.View(viewModel);
        }
    }
}