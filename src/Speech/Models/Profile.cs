using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Speech.Models
{
    [Table("Profiles")]
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public string ClientFirst { get; set; }
        public string ClientLast { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
