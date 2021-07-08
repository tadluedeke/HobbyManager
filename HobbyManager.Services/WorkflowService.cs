using HobbyManager.Data;
using HobbyManager.Models.Paint;
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
                    Color = model.Color,
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


        public WorkflowDetail GetWorkflowById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workflows
                    .Single(e => e.WorkflowId == id && e.OwnerId == _userId);
                return
                    new WorkflowDetail
                    {
                        WorkflowId = entity.WorkflowId,
                        Color = entity.Color,
                        PrimeId = entity.PrimeId,
                        Primer = new PaintDetail
                        {
                            Name = entity.Primer.Name,
                            Brand = entity.Primer.Brand
                        },
                        BaseCoatId = entity.BaseCoatId,
                        BaseCoat = new PaintDetail
                        {
                            Name = entity.BaseCoat.Name
                        },
                        ShadeId = entity.ShadeId,
                        Shade = new PaintDetail
                        {
                            Name = entity.Shade.Name
                        },
                        HighlightOneId = entity.HightlightOneId,
                        HighlightOne = new PaintDetail
                        {
                            Name = entity.HighlightOne.Name
                        },
                        HighlightTwoId = entity.HighlightTwoId,
                        SecondHighlight = new PaintDetail
                        {
                            Name = entity.SecondHighlight.Name
                        }
                    };
            }
        }

        public bool UpdateWorkflow(WorkflowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workflows
                    .Single(e => e.WorkflowId == model.WorkflowId && e.OwnerId == _userId);

                entity.Color = model.Color;
                entity.PrimeId = model.PrimeId;
                entity.BaseCoatId = model.BaseCoatId;
                entity.ShadeId = model.ShadeId;
                entity.HightlightOneId = model.HighlightOneId;
                entity.HighlightTwoId = model.HighlightTwoId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWorkflow(int workflowId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workflows
                    .Single(e => e.WorkflowId == workflowId && e.OwnerId == _userId);

                ctx.Workflows.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
