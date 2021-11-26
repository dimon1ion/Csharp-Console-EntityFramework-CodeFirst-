using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _07_11_2021_Entity_Framework_Core_CodeFirst.Classes
{
    public class Country
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public virtual ICollection<Participants> Participants { get; set; } = new List<Participants>();
    }
}
