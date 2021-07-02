using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.Model
{
    public class ModelDetail
    {
        public int ModelId { get; set; }

        [Display(Name = "Model Name")]
        public string Name { get; set; }

        [Display(Name = "Model Scale")]
        public string Scale { get; set; }

        public string Brand { get; set; }
    }
}
