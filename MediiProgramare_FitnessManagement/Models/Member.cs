using System.ComponentModel.DataAnnotations;

namespace MediiProgramare_FitnessManagement.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Prenumele trebuie să aibă între 3 și 30 de caractere")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$",
            ErrorMessage = "Prenumele trebuie să înceapă cu literă mare (ex: Ana, Ana Maria, Ana-Maria)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Numele trebuie să aibă între 3 și 30 de caractere")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$",
            ErrorMessage = "Numele trebuie să înceapă cu literă mare")]
        public string LastName { get; set; }

        
        
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Numărul de telefon este obligatoriu")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^07\d{2}([ .-]?\d{3}){2}$",
            ErrorMessage = "Telefonul trebuie să fie de forma 0722-123-123, 0722.123.123 sau 0722 123 123")]
        public string Phone { get; set; }
    }
}
