using System.Collections.Generic;

namespace MediiProgramare_FitnessManagement.Models.ViewModels
{
    public class GymIndexData
    {
        public IEnumerable<Gym> Gyms { get; set; }
        public IEnumerable<FitnessClass> FitnessClasses { get; set; }
    }
}
