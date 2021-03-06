﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Speech.Models
{
    [Table("Goals")]
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Completed { get; set; }
        [Required]
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

    }
}
