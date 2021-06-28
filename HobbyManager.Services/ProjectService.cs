using HobbyManager.Data;
using HobbyManager.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    StartDate = model.StartDate,
                    FinishDate = model.FinishDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Projects
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProjectListItem
                        {
                            ProjectId = e.ProjectId,
                            Name = e.Name,
                            StartDate = e.StartDate
                        }
                        );

                return query.ToArray();
            }
        }

        public ProjectDetail GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(e => e.ProjectId == id && e.OwnerId == _userId);
                return
                    new ProjectDetail
                    {
                        ProjectId = entity.ProjectId,
                        Name = entity.Name,
                        StartDate = entity.StartDate,
                        FinishDate = entity.FinishDate
                    };
            }
        }

        public bool UpdateProject(ProjectEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(e => e.ProjectId == model.ProjectId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.StartDate = model.StartDate;
                entity.FinishDate = model.FinishDate;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
