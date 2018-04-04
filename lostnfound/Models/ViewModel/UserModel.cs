using System.ComponentModel.DataAnnotations;

namespace lostnfound.Models.ViewModel
{
    /********************  Models ********************/

    //Log In authentication Model
    public class UserLoginView
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "* required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
    
    //New User Model
    public class CreateUserView
    {
        [Key]

        public int UserID { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber{ get; set; }

        [Required(ErrorMessage = "* required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Passowrd{ get; set; }

        public int RoleID { get; set; }
    }

    //New Reporter Model
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

    //Empty Model - Not Completed Yet 
    //New Item Model
    public class CreateItemView
    {
         
    }
    //NEW METHOD PART3
    public class LookUpAvailableRole
    {
        [Key]
        public int LOOKUPROLEID { get; set; }
        public int ROLEID { get; set; }
        public string TITLE { get; set; }
        //public  PERMISSIONs { get; set; }
    }

    //New Color Model
     public class CreateColorView
     {
         public int ColorID { get; set; }
         public string Title { get; set; }
     }

    //New Location Model
     public class CreateLocationView
     {
         public int LocationID { get; set; }
         public string Title { get; set; }

     }
    
    //New Category Model
     public class CreateCategoryView
     {
         public int CategoryID { get; set; }
         public string Title { get; set; }
     }
}