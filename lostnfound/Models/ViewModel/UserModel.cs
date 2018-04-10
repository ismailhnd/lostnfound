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

        [Required(ErrorMessage = "* required")]
        [Display(Name = "User ID")]
        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Type")]
        public int ItemTypeID { get; set; }
        public string Type { get; set; }
        public List<CreateItemView> TypeInfo { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "State")]
        public int StateID { get; set; }
        public string State { get; set; }
        public List<CreateItemView> StateInfo { get; set; }

        [Display(Name = "Date")]
        public DateTime FLDate { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public List<CreateItemView> CategoryInfo { get; set; }
        
        [Required(ErrorMessage = "* required")]
        [Display(Name = "Color")]
        public int ColorID { get; set; }
        public string Color { get; set; }
        public List<CreateItemView> ColorInfo { get; set; }


        [Required(ErrorMessage = "* required")]
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        public string Location { get; set; }
        public List<CreateItemView> LocationInfo { get; set; }


        public string Image { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Notes or brief description regarding item (brand, size, etc.)")]
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

    //New Item Profile Model
    public class ItemProfileView
    {
        [Key]

        public int ItemID { get; set; }
        public int ReporterID { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "User ID")]
        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Item Type")]
        public int ItemTypeID { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Item State")]
        public int ItemStateID { get; set; }

        public DateTime FLDate { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Color")]
        public int ColorID { get; set; }

        [Required(ErrorMessage = "* required")]
        [Display(Name = "Location")]
        public int LocationID { get; set; }

        public string Image { get; set; }
        public string Notes { get; set; }
    }
    
    public class LookUpItemType
    {
        [Key]
        public int TypeID { get; set; }
        public string Type { get; set; }
    }

    public class LookUpItemState
    {
        [Key]
        public int StateID { get; set; }
        public string State { get; set; }
    }

    public class LookUpItemCategory
    {
        [Key]
        public int CategoryID { get; set; }
        public string Category { get; set; }
    }

    public class LookUpItemColor
    {
        [Key]
        public int ColorID { get; set; }
        public string Color { get; set; }
    }

    public class LookUpItemLocation
    {
        [Key]
        public int LocationID { get; set; }
        public string Location { get; set; }
    }

    public class ItemTypes
    {
        [Key]
        public int ItemTypeID { get; set; }
        public string Type { get; set; }
        public List<ItemTypes> TypeInfo { get; set; }
    }

    public class ItemStates
    {
        [Key]
        public int StateID { get; set; }
        public string State { get; set; }
        public List<ItemStates> StateInfo { get; set; }
    }

    public class ItemCategories
    {
        [Key]
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public List<ItemCategories> CategoryInfo { get; set; }
    }

    public class ItemColors
    {
        [Key]
        public int ColorID { get; set; }
        public string Color { get; set; }
        public List<ItemColors> ColorInfo { get; set; }
    }

    public class ItemLocations
    {
        [Key]
        public int LocationID { get; set; }
        public string Location { get; set; }
        public List<ItemLocations> LocationInfo { get; set; }
    }

    public class ItemDataView
    {
        public List<ItemProfileView> ItemProfile { get; set; }
        public ItemTypes Type { get; set; }
        public ItemStates State { get; set; }
        public ItemCategories Category { get; set; }
        public ItemColors Color { get; set; }
        public ItemLocations Location { get; set; }
    }
}