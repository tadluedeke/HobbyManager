using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.Workflow
{
    public class WorkflowListItem
    {
        public int WorkflowId { get; set; }

        [Display(Name = "Overall Color or Object Painted")]
        public string Color { get; set; }
    }
}
