using System.ComponentModel.DataAnnotations;

namespace MediiProgramare_FitnessManagement.Models
{
    public class ClassType
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeName { get; set; }

        public ICollection<TrainerClassType> TrainerClassTypes { get; set; }
        = new List<TrainerClassType>();
    }
}
