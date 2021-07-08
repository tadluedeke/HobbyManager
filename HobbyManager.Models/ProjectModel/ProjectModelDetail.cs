using HobbyManager.Models.Model;
using HobbyManager.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Models.ProjectModel
{
    public class ProjectModelDetail
    {
        public int ProjectModelId { get; set; }
        public int ProjectId { get; set; }
        public int ModelId { get; set; }

        public virtual ProjectDetail Project { get; set; }
        public virtual ModelDetail Model { get; set; }
    }
}
