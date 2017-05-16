using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Speech.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int Id;
        public string Name;
        public string Description;

        public Review() { }

        public Review(string name, string description, int id=0)
        {
            Name = name;
            Description = description;
            Id = id;
        }
        
    }
}
