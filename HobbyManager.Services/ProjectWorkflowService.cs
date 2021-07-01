using HobbyManager.Data;
using HobbyManager.Models.ProjectWorkflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Services
{
    public class ProjectWorkflowService
    {
        private readonly Guid _userId;

        public ProjectWorkflowService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateProjectWorkflow(ProjectWorkflowCreate model)
        {
            var entity =
                new ProjectWorkflow()
                {
                    OwnerId = _userId,
                    WorkflowId = model.WorkflowId,
                    ProjectId = model.ProjectId
                };
            using (var ctx2 = new ApplicationDbContext())
            {
                ctx2.ProjectWorkflows.Add(entity);
                return ctx2.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectWorkflowListItem> GetProjectWorkflows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ProjectWorkflows
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProjectWorkflowListItem
                        {
                            ProjectWorkflowId = e.ProjectWorkflowId,
                            ProjectId = e.ProjectId,
                            WorkflowId = e.WorkflowId
                        }
                        );
                return query.ToArray();
            }
        }

        public ProjectWorkflowDetail GetProjectWorkflowById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProjectWorkflows
                    .Single(e => e.ProjectWorkflowId == id && e.OwnerId == _userId);
                return
                    new ProjectWorkflowDetail
                    {
                        ProjectWorkflowId = entity.ProjectWorkflowId,
                        ProjectId = entity.ProjectId,
                        WorkflowId = entity.WorkflowId
                    };
            }
        }

        public bool UpdateProjectWorkflow(ProjectWorkflowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProjectWorkflows
                    .Single(e => e.ProjectWorkflowId == model.ProjectWorkflowId && e.OwnerId == _userId);

                entity.ProjectWorkflowId = model.ProjectWorkflowId;
                entity.ProjectId = model.ProjectId;
                entity.WorkflowId = model.WorkflowId;

                return ctx.SaveChanges() == 1;
            }
        }

    }

}
