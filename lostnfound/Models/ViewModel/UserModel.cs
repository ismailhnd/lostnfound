using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace lostnfound.Models.ViewModel
{


    public class CreateUserView
    {
        [Key]

        
        public int UserID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber{ get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Passowrd{ get; set; }

        [ForeignKey("UserID")]
        public int RoleID { get; set; }
    }

    public class CreateReporterView
    {
        [Key]

        public int ReporterID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        
        public bool AUB { get; set; } 
        public string VerificationDocument { get; set; }
    }

    public class CreateItemView
    {
        [Key]

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        public bool AUB { get; set; }
        public string VerificationDocument { get; set; }
    }

    public class CreateColorView
    {
        public int ColorID { get; set; }
        public string Title { get; set; }
    }


    public class CreateLocationView
    {
        public int LocationID { get; set; }
        public string Title { get; set; }

    }

    public class CreateCategoryView
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
    }
}