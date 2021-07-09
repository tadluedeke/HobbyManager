using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Data
{
    public class WorkflowPaints
    {
        [Key]
        public int WorkflowPaintId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int WorkflowId { get; set; }
        public virtual Workflow Workflow { get; set; }

        [Required]
        public int PaintId { get; set; }
        public virtual Paint Paint { get; set; }
    }
}
