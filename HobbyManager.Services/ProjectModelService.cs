using HobbyManager.Data;
using HobbyManager.Models.Model;
using HobbyManager.Models.Project;
using HobbyManager.Models.ProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Services
{
    public class ProjectModelService
    {
        private readonly Guid _userId;

        public ProjectModelService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProjectModel(ProjectModelCreate model)
        {
            var entity =
                new ProjectModel()
                {
                    OwnerId = _userId,
                    ProjectId = model.ProjectId,
                    ModelId = model.ModelId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProjectModels.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectModelListItem> GetProjectModels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ProjectModels
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProjectModelListItem
                        {
                            ProjectModelId = e.ProjectModelId,
                            ProjectId = e.ProjectId,
                            Project = new ProjectDetail
                            {
                                Name = e.Project.Name
                            },
                            ModelId = e.ModelId,
                            Model = new ModelDetail
                            {
                                Name = e.Model.Name
                            }
                        }
                        );
                return query.ToArray();
            }
        }

        public ProjectModelDetail GetProjectModelById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProjectModels
                    .Single(e => e.ProjectModelId == id && e.OwnerId == _userId);
                return
                    new ProjectModelDetail
                    {
                        ProjectModelId = entity.ProjectModelId,
                        ProjectId = entity.ProjectId,
                        Project = new ProjectDetail
                        {
                            Name = entity.Project.Name
                        },
                        ModelId = entity.ModelId,
                        Model = new ModelDetail
                        {
                            Name = entity.Model.Name
                        }
                    };
            }
        }

        public bool UpdateProjectModel(ProjectModelEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProjectModels
                    .Single(e => e.ProjectModelId == model.ProjectModelId && e.OwnerId == _userId);

                entity.ProjectModelId = model.ProjectModelId;
                entity.ProjectId = model.ProjectId;
                entity.ModelId = model.ModelId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProjectModel(int projectModelId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProjectModels
                    .Single(e => e.ProjectModelId == projectModelId && e.OwnerId == _userId);

                ctx.ProjectModels.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
