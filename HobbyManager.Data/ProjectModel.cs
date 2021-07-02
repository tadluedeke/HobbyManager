using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Data
{
    public class ProjectModel
    {
        [Key]
        public int ProjectModelId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [Required]
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        
        public virtual IEnumerable<Project> Projects { get; set; }
        public virtual IEnumerable<Model> Models { get; set; }
    }
}
