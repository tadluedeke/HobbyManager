using HobbyManager.Models.Paint;
using HobbyManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.Workflow
{
    public class WorkflowCreate
    {
        [Required]
        [Display(Name = "Overall Color or Object Painted")]
        public string Color { get; set; }

        public int PrimeId { get; set; }
        public int BaseCoatId { get; set; }
        public int ShadeId { get; set; }
        public int HighlightOneId { get; set; }
        public int HighlightTwoId { get; set; }
    }
}