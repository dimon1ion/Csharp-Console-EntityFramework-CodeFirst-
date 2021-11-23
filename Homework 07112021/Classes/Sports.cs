using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _07_11_2021_Entity_Framework_Core_CodeFirst.Classes
{
    public class Sports
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        public ICollection<ParticipantsSportsMedals> ParticipantsSportsMedals { get; set; }
    }
}
