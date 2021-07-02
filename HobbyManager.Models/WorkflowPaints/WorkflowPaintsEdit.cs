using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.WorkflowPaints
{
    public class WorkflowPaintsEdit
    {
        public int WorkflowPaintsId { get; set; }

        [Required]
        public int WorkflowId { get; set; }

        [Required]
        public int PaintId { get; set; }
    }
}
