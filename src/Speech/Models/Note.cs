using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Speech.Models
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

    }
}
