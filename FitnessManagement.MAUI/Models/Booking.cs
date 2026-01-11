using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessManagement.MAUI.Models
{
    public class Booking
    {
        public int ID {  get; set; }

        public int FitnessClassID { get; set; }

        //date afisabile 
        public string ClassName { get; set; }
        public string TrainerName { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
