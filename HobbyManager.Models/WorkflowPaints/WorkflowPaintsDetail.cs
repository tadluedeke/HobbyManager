using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.WorkflowPaints
{
    public class WorkflowPaintsDetail
    {
        public int WorkflowPaintsId { get; set; }
        public int WorkflowId { get; set; }
        public int PaintId { get; set; }

        public virtual IEnumerable<HobbyManager.Data.Workflow> Workflow { get; set; }
        public virtual IEnumerable<HobbyManager.Data.Paint> Paint { get; set; }
    }
}
