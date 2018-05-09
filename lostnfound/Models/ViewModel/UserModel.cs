using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lostnfound.Models.ViewModel
{
    /*############################################### Home Models ###############################################*/
    public class LoginModel
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

    public class Items
    {
        [Key]
        public int ItemID { get; set; }
        public string Reporter { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ItemType { get; set; }
        public string State { get; set; }
        public DateTime FLDate { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public string Notes { get; set; }
    }

    /*############################################ Preferences Models ############################################*/
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Last Name")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "* required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Role")]
        public int RoleID { get; set; }
        public string Title { get; set; }
        public List<User> roleinfo { get; set; }
    }

    public class Color
    {
        public int ColorID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Color")]
        public string Title { get; set; }

    }

    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Category")]
        public string Title { get; set; }

    }

    public class Location
    {
        public int LocationID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Location")]
        public string Title { get; set; }

    }

    public class Role
    {
        public int RoleID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Role")]
        public string Title { get; set; }

    }

    public class State
    {
        public int StateID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "State")]
        public string Title { get; set; }

    }

    public class ItemType
    {
        public int TypeID { get; set; }
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Type")]
        public string Title { get; set; }

    }
    /*############################################### Items Models ###############################################*/
    
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Reporter")]
        public int ReporterID { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Reporter Name")]
        public string ReporterName { get; set; }

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


        [Required(ErrorMessage = "* required")]
        [Display(Name = "User Name")]
        public int CreatedByID { get; set; }
        public string UserName { get; set; }
        public List<Item> userinfo { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Type")]
        public int ItemTypeID { get; set; }
        public string Type { get; set; }
        public List<Item> typeinfo { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "State")]
        public int StateID { get; set; }
        public string State { get; set; }
        public List<Item> stateinfo { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FLDate { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public List<Item> categoryinfo { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Color")]
        public int ColorID { get; set; }
        public string Color { get; set; }
        public List<Item> colorinfo { get; set; }


        [Required(ErrorMessage = "* required")]
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        public string Location { get; set; }
        public List<Item> locationinfo { get; set; }


        public string Image { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
    
}

