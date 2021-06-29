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

        [Display(Name ="Overall Color or Object Painted")]
        public string Color { get; set; }

        [Display(Name ="Primer used")]
        public Paint Prime { get; set; }

        [Display(Name ="Base coat paint used")]
        public Paint BaseCoat { get; set; }

        [Display(Name ="Wash used")]
        public Paint Shade { get; set; }

        [Display(Name ="First hightlight paint used")]
        public Paint HightlightOne { get; set; }

        [Display(Name ="Second highlight paint used")]
        public Paint HighlightTwo { get; set; }
    }
}
