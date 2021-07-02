using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.Project
{
    public class ProjectDetail
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Started")]
        public DateTimeOffset StartDate { get; set; }

        [Display(Name = "Finished")]
        public DateTimeOffset? FinishDate { get; set; }
    }
}
