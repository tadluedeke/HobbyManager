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

        public Paint Prime { get; set; }
        public List<Paint> BaseCoat { get; set; }
        public List<Paint> Shade { get; set; }
        public List<Paint> HightlightOne { get; set; }
        public List<Paint> HighlightTwo { get; set; }
    }
}
