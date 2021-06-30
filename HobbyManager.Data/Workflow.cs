using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        //[ForeignKey(nameof(Primer))]
        public int PrimeId { get; set; }

        [Display(Name = "Base coat paint used")]
        //[ForeignKey(nameof(BaseCoat))]
        public int BaseCoatId { get; set; }

        [Display(Name = "Wash used")]
        //[ForeignKey(nameof(Shade))]
        public int ShadeId { get; set; }

        [Display(Name = "First hightlight paint used")]
        //[ForeignKey(nameof(HighlightOne)]
        public int HightlightOneId { get; set; }

        [Display(Name = "Second highlight paint used")]
        //[ForeignKey(nameof(ThisIsATest))]
        public int HighlightTwoId { get; set; }
        public virtual Paint Primer { get; set; }
        public virtual Paint BaseCoat { get; set; }
        public virtual Paint Shade { get; set; }
        public virtual Paint HighlightOne { get; set; }
        public virtual Paint SecondHighlight { get; set; }
    }
}
