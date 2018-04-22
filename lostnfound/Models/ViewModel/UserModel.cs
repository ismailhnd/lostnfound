using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lostnfound.Models.ViewModel
{
    /******************** Home Models ********************/

    //Log In authentication Model
    public class UserLoginView
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "* required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    /******************** Preferences Models ********************/

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
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "* required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public int RoleID { get; set; }
        public string Title { get; set; }
        public List<CreateUserView> roleinfo { get; set; }
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

    /******************** Item Models ********************/

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

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Reporter")]
        public int ReporterID { get; set; }
        public string FirstName { get; set; }
        public List<CreateItemView> reporterinfo { get; set; }


        [Required(ErrorMessage = "* required")]
        [Display(Name = "User")]
        public int CreatedByID { get; set; }
        public string fname { get; set; }
        public List<CreateItemView> userinfo { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Type")]
        public int ItemTypeID { get; set; }
        public string Type { get; set; }
        public List<CreateItemView> typeinfo { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "State")]
        public int StateID { get; set; }
        public string State { get; set; }
        public List<CreateItemView> stateinfo { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FLDate { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public List<CreateItemView> categoryinfo { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Color")]
        public int ColorID { get; set; }
        public string Color { get; set; }
        public List<CreateItemView> colorinfo { get; set; }


        [Required(ErrorMessage = "* required")]
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        public string Location { get; set; }
        public List<CreateItemView> locationinfo { get; set; }


        public string Image { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }

    
}