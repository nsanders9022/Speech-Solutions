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
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public Review() { }

        //public Review(string name, string description, int id=0)
        //{
        //    Name = name;
        //    Description = description;
        //    Id = id;
        //}

    }
}
