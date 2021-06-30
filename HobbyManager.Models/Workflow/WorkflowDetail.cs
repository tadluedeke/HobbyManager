using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.Workflow
{
    public class WorkflowDetail
    {
        public int WorkflowId { get; set; }

        [Display(Name = "Overall Color or Object Painted")]
        public string Color { get; set; }

        [Display(Name = "Primer")]
        public int PrimeId { get; set; }

        [Display(Name = "Base Coat")]
        public int BaseCoatId { get; set; }

        [Display(Name = "Shade/Wash")]
        public int ShadeId { get; set; }

        [Display(Name = "Highlight One")]
        public int HighlightOneId { get; set; }

        [Display(Name = "Highlight Two")]
        public int HighlightTwoId { get; set; }
    }
}
