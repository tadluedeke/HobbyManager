using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }
    }
}
