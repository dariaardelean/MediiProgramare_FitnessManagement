using System;
using System.ComponentModel.DataAnnotations;

namespace MediiProgramare_FitnessManagement.Models
{
    public class FitnessClass
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; } = null!;

        [Display(Name = "Scheduled Date")]
        [DataType(DataType.DateTime)]
        public DateTime ScheduleDate { get; set; }

        // FK Trainer
        public int TrainerID { get; set; }
        public Trainer? Trainer { get; set; } = null!;

        // FK ClassType
        public int ClassTypeID { get; set; }
        public ClassType? ClassType { get; set; } = null!;

        // FK Gym
        public int? GymID { get; set; }
        public Gym? Gym { get; set; }
    }
}
