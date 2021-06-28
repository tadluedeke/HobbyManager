using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.Project
{
    public class ProjectCreate
    {
        public string Name { get; set; }

        [Required]
        [Display(Name = "Started")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Finished")]
        public DateTime? FinishDate { get; set; }
    }
}
