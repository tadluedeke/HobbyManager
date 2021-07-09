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
        [MinLength(1, ErrorMessage ="You must name your project with at least one character.")]
        [MaxLength(30, ErrorMessage ="There are too many characters in this field.")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Started")]
        public DateTimeOffset StartDate { get; set; }

        [Display(Name="Finished")]
        public DateTimeOffset? FinishDate { get; set; }
    }
}
