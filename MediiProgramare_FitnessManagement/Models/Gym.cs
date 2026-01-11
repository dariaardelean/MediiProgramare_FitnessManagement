using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MediiProgramare_FitnessManagement.Models
{
    public class Gym
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Gym Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Address")]
        public string Address { get; set; }

        // navigation property (ca Publisher -> Books)
        public ICollection<FitnessClass>? FitnessClasses { get; set; }
         = new List<FitnessClass>();
    }
}
