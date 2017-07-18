using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using System.Web;

namespace Speech.Models
{
    public class Contact
    {
        [Required(ErrorMessage ="*First name is requried")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Last name is requried")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*An email address is requried")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*A comment is requried")]
        public string Comment { get; set; }
    }
}
