using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Data
{
    public class ProjectWorkflow
    {
        [Key]
        public int ProjectWorkflowId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [Required]
        public int WorkflowId { get; set; }
        public virtual Workflow Workflow { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }
        public virtual IEnumerable<Workflow> Workflows { get; set; }
    }
}
