using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _07_11_2021_Entity_Framework_Core_CodeFirst.Classes
{
    public class Participants
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<ParticipantsSportsMedals> ParticipantsSportsMedals { get; set; }
    }
}
