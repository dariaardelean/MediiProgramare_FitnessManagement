namespace MediiProgramare_FitnessManagement.Models
{
    public class TrainerClassType
    {
        public int TrainerID { get; set; }
        public Trainer Trainer { get; set; }

        public int ClassTypeID { get; set; }
        public ClassType ClassType { get; set; }
    }
}
