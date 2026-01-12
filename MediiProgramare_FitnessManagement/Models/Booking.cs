using System;
using System.ComponentModel.DataAnnotations;
using MediiProgramare_FitnessManagement.Models;

namespace MediiProgramare_FitnessManagement.Models
{
    public class Booking
    {
        public int ID { get; set; }

        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        //FK catre Member
        public int MemberID { get; set; }
        public Member? Member { get; set; }

        //FK catre class
        public int FitnessClassID { get; set; }
        public FitnessClass? FitnessClass { get; set; }

    }
}
