using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretSanta.Models
{
    public class ParticipantModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}