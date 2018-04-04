using System;
using System.Linq;
using lostnfound.Models.DB;
using lostnfound.Models.ViewModel;

namespace lostnfound.Models.EntityManager
{
    public class UserManager
    {

        /********************  Main Functions ********************/

        //Add new User
        public void AddUserAccount(CreateUserView userView)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                USER staff = new USER
                {
                    USERID = UniqueID("User"),
                    FIRSTNAME = userView.FirstName,
                    LASTNAME = userView.LastName,
                    EMAIL = userView.Email,
                    PHONENUMBER = userView.PhoneNumber,
                    PASSWORD = userView.Passowrd
                };
                staff.FIRSTNAME = userView.FirstName;
                staff.ROLEID = userView.RoleID;
                db.USERs.Add(staff);
                db.SaveChanges();
            }
        }

        //Add new Reporter
        public void AddReporterAccount(CreateReporterView reporterView)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                REPORTER reporter = new REPORTER
                {
                    REPORTERID = UniqueID("Reporter"),
                    FIRSTNAME = reporterView.FirstName,
                    LASTNAME = reporterView.LastName,
                    EMAIL = reporterView.Email,
                    PHONENUMBER = reporterView.PhoneNumber,
                    IDDOCUMENT = reporterView.VerificationDocument,
                    AUB = reporterView.AUB
                };
                db.REPORTERs.Add(reporter);
                db.SaveChanges();
            }
        }

        //Add new item
        public void AddItemToDatabase(CreateItemView itemView)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                ITEM item = new ITEM
                {
                    ITEMID = UniqueID("Item"),
                    REPORTERID = itemView.ReporterID,
                    CREATEDBYID = itemView.CreatedByID,
                    CREATEDDATE = itemView.CreatedDate,
                    ITEMTYPEID = itemView.ItemTypeID,
                    STATEID = itemView.StateID,
                    FLDATE = itemView.FLDateID,
                    CATEGORYID = itemView.CategoryID,
                    COLORID = itemView.ColorID,
                    LOCATIONID = itemView.LocationID,
                    IMAGE = itemView.Image,
                    NOTES = itemView.Notes
                };
            }
        }

        //Add new color
        public void AddColorToDatabase(CreateColorView colorView)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                COLOR color = new COLOR
                {
                    COLORID = UniqueID("Color"),
                    TITLE = colorView.Title
                };
            }
        }

        //Add new location
        public void AddLocationToDatabase(CreateLocationView locationView)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                LOCATION location = new LOCATION
                {
                    LOCATIONID = UniqueID("Location"),
                    TITLE = locationView.Title
                };
            }
        }

        //Add new category
        public void AddCategoryToDatabase(CreateCategoryView categoryView)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                CATEGORY category = new CATEGORY
                {
                    CATEGORYID = UniqueID("Category"),
                    TITLE = categoryView.Title
                };
            }
        }

        /********************  Sepcial Functions ********************/

        //Check if email already exists in the database 
        public bool IsEmailExist(string email)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                return db.USERs.Where(o => o.EMAIL.Equals(email)).Any();
            }
        }

        //Generate a unique identifier between 1 and 1000
        public int UniqueID(string table)
        {
            Random rnd = new Random();
            int unique = rnd.Next(1, 1000);

            if (IsIDExist(unique, table))
            {
                return UniqueID(table);
            }
            else
            {
                return unique;
            }
        }
        
        //Get password from database
        public string GetUserPassword(string email)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                var user = db.USERs.Where(o => o.EMAIL.ToLower().Equals(email));
                if (user.Any())
                    return user.FirstOrDefault().PASSWORD;
                else
                    return string.Empty;
            }
        }

        //Verify User's role
        public bool IsUserInRole(string email, string roleTitle)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                USER user = db.USERs.Where(o => o.EMAIL.ToLower().Equals(email))?.FirstOrDefault();
                if (user != null)
                {
                    var roles = from q in db.USERs
                                join r in db.ROLEs on q.ROLEID equals r.ROLEID
                                where r.TITLE.Equals(roleTitle) && q.USERID.Equals(user.USERID)
                                select r.TITLE;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }
                return false;
            }
        }
        
        
        /********************  Private Functions ********************/

        //Check if ID already exist in database
        private bool IsIDExist(int id, string table)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                if (table == "User")
                {
                    return db.USERs.Where(o => o.USERID.Equals(id)).Any();
                }
                else if (table == "Reporter")
                {
                    return db.REPORTERs.Where(o => o.REPORTERID.Equals(id)).Any();
                }
                else if (table == "Item")
                {
                    return db.ITEMs.Where(o => o.ITEMID.Equals(id)).Any();
                }
                else if (table == "Color")
                {
                    return db.COLORs.Where(o => o.COLORID.Equals(id)).Any();
                }
                else if (table == "Location")
                {
                    return db.LOCATIONs.Where(o => o.LOCATIONID.Equals(id)).Any();
                }
                else if (table == "CATEGORY")
                {
                    return db.CATEGORies.Where(o => o.CATEGORYID.Equals(id)).Any();
                }
                else
                {
                    return false;
                }

            }
        }

    }


}