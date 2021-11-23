using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _07_11_2021_Entity_Framework_Core_CodeFirst.Classes
{
    public enum Medal
    {
        Gold = 1, Silver, Bronze, No
    }
    public class Medals
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public Medal Type { get; set; }


        public ICollection<ParticipantsSportsMedals> ParticipantsSportsMedals { get; set; }
    }
}
