using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.Paint
{
    public class PaintEdit
    {
        public int PaintId { get; set; }
        public string Brand { get; set; }

        [Display(Name = "Paint Name")]
        public string Name { get; set; }
        public string Color { get; set; }

        [Display(Name = "Product SKU")]
        public string SKU { get; set; }
    }
}
