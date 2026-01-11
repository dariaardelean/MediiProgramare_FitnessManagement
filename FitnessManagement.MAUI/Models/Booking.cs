using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessManagement.MAUI.Models
{
    public class Booking
    {
        public int ID {  get; set; }

        [Required(ErrorMessage = "Clasa este obligatorie")]
        public int FitnessClassID { get; set; }

        //date afisabile 
        [Required(ErrorMessage = "Numele clasei este obligatoriu")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "Numele trainerului este obligatoriu")]
        public string TrainerName { get; set; }
       
        [Required(ErrorMessage = "Data este obligatorie")]
        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; }
    }
}
