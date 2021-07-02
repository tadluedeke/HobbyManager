using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.ProjectWorkflow
{
    public class ProjectWorkflowCreate
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int WorkflowId { get; set; }
    }
}
