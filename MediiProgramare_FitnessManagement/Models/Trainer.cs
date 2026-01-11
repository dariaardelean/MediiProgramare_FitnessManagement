using System.ComponentModel.DataAnnotations;

namespace MediiProgramare_FitnessManagement.Models
{
    public class Trainer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]

        [Display(Name = "Specialization")]
        public string Specialty { get; set; }

        public ICollection<TrainerClassType> TrainerClassTypes { get; set; }
         = new List<TrainerClassType>();
    }
}
