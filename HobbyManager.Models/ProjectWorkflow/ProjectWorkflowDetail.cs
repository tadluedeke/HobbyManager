using HobbyManager.Models.Project;
using HobbyManager.Models.Workflow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.ProjectWorkflow
{
    public class ProjectWorkflowDetail
    {
        public int ProjectWorkflowId { get; set; }
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        [Display(Name = "Workflow Used")]
        public int WorkflowId { get; set; }

        public virtual ProjectDetail Project { get; set; }
        public virtual WorkflowDetail Workflow { get; set; } 
    }
}
