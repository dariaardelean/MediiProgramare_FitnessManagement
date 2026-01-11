using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessManagement.MAUI.Models
{
    public class FitnessClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TrainerName { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
