using System;
using System.Collections.Generic;
using System.Linq;
using lostnfound.Models.DB;
using lostnfound.Models.ViewModel;

namespace lostnfound.Models.EntityManager
{
    public class UserManager
    {
        /********************  Main Functions ********************/

        //Add new User
        public void AddUserAccount(CreateUserView user)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                USER staff = new USER
                {
                    FIRSTNAME = user.FirstName,
                    LASTNAME = user.LastName,
                    EMAIL = user.Email,
                    PHONENUMBER = user.PhoneNumber,
                    PASSWORD = user.Password
                };
                staff.ROLEID = user.RoleID;
                db.USERs.Add(staff);
                db.SaveChanges();
            }
            
        }

        //Add new Reporter
        public void AddReporterAccount(CreateReporterView user)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                REPORTER reporter = new REPORTER
                {
                    FIRSTNAME = user.FirstName,
                    LASTNAME = user.LastName,
                    EMAIL = user.Email,
                    PHONENUMBER = user.PhoneNumber,
                    IDDOCUMENT = user.VerificationDocument,
                    AUB = user.AUB
                };
                db.REPORTERs.Add(reporter);
                db.SaveChanges();
            }
        }

        //Add new item
        public void AddItem(CreateItemView data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                ITEM item = new ITEM
                {
                    REPORTERID = data.ReporterID,
                    CREATEDBYID = data.CreatedByID,
                    CREATEDDATE = data.CreatedDate,
                    ITEMTYPEID = data.ItemTypeID,
                    STATEID = data.ItemStateID,
                    FLDATE = data.FLDate,
                    CATEGORYID = data.CategoryID,
                    COLORID = data.ColorID,
                    LOCATIONID = data.LocationID,
                    IMAGE = data.Image,
                    NOTES = data.Notes
                };
                db.ITEMs.Add(item);
                db.SaveChanges();
            }
        }

        //Add new color
        public void AddColor(CreateColorView data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                COLOR color = new COLOR
                {
                    TITLE = data.Title
                };
                db.COLORs.Add(color);
                db.SaveChanges();
            }

        }

        //Add new location
        public void AddLocation(CreateLocationView data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                LOCATION location = new LOCATION
                {
                    TITLE = data.Title
                };

                db.LOCATIONs.Add(location);
                db.SaveChanges();
            }
        }

        //Add new category
        public void AddCategory(CreateCategoryView data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                CATEGORY category = new CATEGORY
                {
                    TITLE = data.Title
                };
                db.CATEGORies.Add(category);
                db.SaveChanges();
            }
        }

        /********************  DDL Functions ********************/

        public CreateUserView RoleOptions()
        {

            CreateUserView roleView = new CreateUserView();
            using (lostfoundDB db = new lostfoundDB())
            {
                List<CreateUserView> userlist = new List<CreateUserView>();
                foreach (ROLE r in db.ROLEs)
                {
                    CreateUserView temp = new CreateUserView();
                    temp.RoleID = r.ROLEID;
                    temp.Title = r.TITLE;
                    userlist.Add(temp);

                }

                roleView.roleinfo = userlist;
            }
            return roleView;
        }

        public CreateItemView ItemOptions()
        {

            CreateItemView itemView = new CreateItemView();
            using (lostfoundDB db = new lostfoundDB())
            {
                List<CreateItemView> itemTypeList = new List<CreateItemView>();
                foreach (ITEMTYPE i in db.ITEMTYPEs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.ItemTypeID = i.ITEMTYPEID;
                    itemTypeList.Add(temp);
                }
               itemView.TypeInfo = itemTypeList;

                List<CreateItemView> itemStateList = new List<CreateItemView>();
                foreach (ITEMSTATE i in db.ITEMSTATEs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.ItemStateID = i.ITEMSTATEID;
                    itemStateList.Add(temp);
                }
                itemView.StateInfo = itemStateList;

                List<CreateItemView> categoryList = new List<CreateItemView>();
                foreach (CATEGORY c in db.CATEGORies)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.CategoryID = c.CATEGORYID;
                    categoryList.Add(temp);
                }
                itemView.CategoryInfo = categoryList;

                List<CreateItemView> colorList = new List<CreateItemView>();
                foreach (COLOR c in db.COLORs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.ColorID = c.COLORID;
                    colorList.Add(temp);
                }
                itemView.ColorInfo = colorList;

                List<CreateItemView> locationList = new List<CreateItemView>();
                foreach (LOCATION l in db.LOCATIONs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.LocationID = l.LOCATIONID;
                    locationList.Add(temp);
                }
                itemView.LocationInfo = locationList;
            }
            return itemView;
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
    }
}