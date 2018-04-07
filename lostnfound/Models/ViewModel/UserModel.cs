using System;
using System.Collections.Generic;
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
        public string Password{ get; set; }

        [Display(Name = "Role")]
        public int RoleID { get; set; }
        public string Title { get; set; }
        public List<CreateUserView> roleinfo { get; set; }
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
    
    //New Item Model
    public class CreateItemView
    {
        [Key]

        public int ItemID { get; set; }           
        public int ReporterID { get; set; }
        public int CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ItemTypeID { get; set; }
        public int StateID { get; set; }
        public DateTime FLDateID { get; set; }
        public int CategoryID { get; set; }
        public int ColorID { get; set; }
        public int LocationID { get; set; }
        public string Image { get; set; }
        public string Notes { get; set; }
    }

    //New Color Model
     public class CreateColorView
     {
        public int ColorID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Color")]
        public string Title { get; set; }
     }

    //New Location Model
     public class CreateLocationView
     {
        public int LocationID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Location")]
        public string Title { get; set; }

     }
    
    //New Category Model
     public class CreateCategoryView
     {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Category")]
        public string Title { get; set; }
     }

    /* //Role DropDownList
     public class RoleDetails
     {
         [Key]
         public int RoleID { get; set; }
         public string Title { get; set; }
         public List<RoleDetails> roleinfo { get; set; } 
     }*/
   

}