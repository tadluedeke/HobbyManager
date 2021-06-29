using HobbyManager.Data;
using HobbyManager.Models.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Services
{
    public class WorkflowService
    {
        private readonly Guid _userId;

        public WorkflowService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateWorkflow(WorkflowCreate model)
        {
            var entity =
                new Workflow()
                {
                    OwnerId = _userId,
                    PrimeId = model.PrimeId,
                    BaseCoatId = model.BaseCoatId,
                    ShadeId = model.ShadeId,
                    HightlightOneId = model.HighlightOneId,
                    HighlightTwoId = model.HighlightTwoId
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Workflows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkflowListItem> GetWorkflows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Workflows
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new WorkflowListItem
                        {
                            WorkflowId = e.WorkflowId,
                            Color = e.Color
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
