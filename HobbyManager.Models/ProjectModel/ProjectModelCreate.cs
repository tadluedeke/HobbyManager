using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.ProjectModel
{
    public class ProjectModelCreate
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int ModelId { get; set; }
    }
}
