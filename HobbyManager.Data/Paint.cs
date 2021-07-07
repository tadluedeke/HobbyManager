using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Data
{
    public class Paint
    {
        [Key]
        public int PaintId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Name { get; set; }

        public string Color { get; set; }

        public string SKU { get; set; }

        public virtual ICollection<Workflow> Primers { get; set; }
        public virtual ICollection<Workflow> BaseCoat { get; set; }
        public virtual ICollection<Workflow> Shade { get; set; }
        public virtual ICollection<Workflow> HighlightOne { get; set; }
        public virtual ICollection<Workflow> SecondHighlight { get; set; }

        public virtual Workflow PrimeId { get; set; }
    }
}
