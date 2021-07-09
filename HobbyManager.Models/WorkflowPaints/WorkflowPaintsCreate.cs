using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.WorkflowPaints
{
    public class WorkflowPaintsCreate
    {
        [Required]
        public int WorkflowId { get; set; }

        [Required]
        public int PaintId { get; set; }
    }
}
