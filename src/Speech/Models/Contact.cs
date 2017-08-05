using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Speech.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "*First name is requried")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Last name is requried")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*An email address is requried")]
        [EmailAddress(ErrorMessage = "Invalid email address. Valid e-mail can contain only latin letters, numbers, '@' and '.'")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*A comment is requried")]
        public string Comment { get; set; }
    }
}
