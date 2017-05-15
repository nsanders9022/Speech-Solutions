using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using RestSharp;
//using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Speech.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Comment { get; set; }

        public Client() { }

        public Client (string firstName, string lastName, DateTime birthday, string comment, int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = birthday;
            Comment = comment;
            ClientId = id;
        }




    }
}
