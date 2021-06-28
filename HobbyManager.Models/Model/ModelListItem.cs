using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models
{
    public class ModelListItem
    {
        public int ModelId { get; set; }

        [Display(Name = "Model Name")]
        public string Name { get; set; }

        public string Brand { get; set; }
    }
}
