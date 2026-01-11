using System.ComponentModel.DataAnnotations;

namespace MediiProgramare_FitnessManagement.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }
       
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}
