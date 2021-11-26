using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _07_11_2021_Entity_Framework_Core_CodeFirst.Classes
{
    public class ParticipantsSportsMedals
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int ParticipantId { get; set; }

        [Required]
        public int SportId { get; set; }

        [Required]
        public int MedalsId { get; set; }

        public virtual Participants Participant { get; set; }
        public virtual Sports Sport { get; set; }
        public virtual Medals Medal { get; set; }
    }
}
