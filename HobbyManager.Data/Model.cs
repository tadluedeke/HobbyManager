﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyManager.Data
{
   public class Model
    {
        [Key]
        public int ModelId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Scale { get; set; }

        [Required]
        public string Brand { get; set; }
    }
}
