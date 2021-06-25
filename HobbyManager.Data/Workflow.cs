using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Data
{
    public class Workflow
    {
        [Key]
        public int WorkflowId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Display(Name ="Primer used")]
        public Paint Prime { get; set; }

        [Display(Name ="Base coat paints used")]
        public List<Paint> BaseCoat { get; set; }

        [Display(Name ="Wash used")]
        public List<Paint> Shade { get; set; }

        [Display(Name ="First hightlight paints used")]
        public List<Paint> HightlightOne { get; set; }

        [Display(Name ="Second highlight paints used")]
        public List<Paint> HighlightTwo { get; set; }
    }
}
