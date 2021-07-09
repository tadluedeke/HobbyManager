using HobbyManager.Models.Project;
using HobbyManager.Models.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.ProjectWorkflow
{
    public class ProjectWorkflowListItem
    {
        public int ProjectWorkflowId { get; set; }
        public int ProjectId { get; set; }
        public int WorkflowId { get; set; }

        public virtual ProjectDetail Project { get; set; }
        public virtual WorkflowDetail Workflow { get; set; }
    }
}
