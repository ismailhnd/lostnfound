using System;
using System.Collections.Generic;
using System.Linq;
using lostnfound.Models.DB;
using lostnfound.Models.ViewModel;
using lostnfound.Security;

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
                    USERID = UniqueID("User"),
                    FIRSTNAME = user.FirstName,
                    LASTNAME = user.LastName,
                    EMAIL = user.Email,
                    PHONENUMBER = user.PhoneNumber,
                    PASSWORD = Encrypt(user.Password),
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
                    ITEMID = UniqueID("Item"),
                    REPORTERID = data.ReporterID,
                    ITEMTYPEID = data.ItemTypeID,
                    CREATEDDATE = DateTime.Now.Date,
                    STATEID = data.StateID,
                    FLDATE = DateTime.Now.Date,
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
        public void AddColor(PreferencesView data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                COLOR color = new COLOR
                {
                    TITLE = data.Location
                };
                db.COLORs.Add(color);
                db.SaveChanges();
            }

        }

        //Add new location
        public void AddLocation(PreferencesView data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                LOCATION location = new LOCATION
                {
                    TITLE = data.Color
                };

                db.LOCATIONs.Add(location);
                db.SaveChanges();
            }
        }

        //Add new category
        public void AddCategory(PreferencesView data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                CATEGORY category = new CATEGORY
                {
                    TITLE = data.Category
                };
                db.CATEGORies.Add(category);
                db.SaveChanges();
            }
        }

        /********************  DDL Functions ********************/

        //DropdownLIst with all role Options found
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

                List<CreateItemView> userList = new List<CreateItemView>();
                foreach (USER i in db.USERs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.CreatedByID = i.USERID;
                    temp.fname = i.FIRSTNAME;
                    userList.Add(temp);
                }
                itemView.userinfo = userList;

                List<CreateItemView> reporterList = new List<CreateItemView>();
                foreach (REPORTER i in db.REPORTERs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.ReporterID = i.REPORTERID;
                    temp.FirstName = i.FIRSTNAME;
                    reporterList.Add(temp);
                }
                itemView.reporterinfo = reporterList;
                List<CreateItemView> itemTypeList = new List<CreateItemView>();
                foreach (ITEMTYPE i in db.ITEMTYPEs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.ItemTypeID = i.ITEMTYPEID;
                    temp.Type = i.TITLE;
                    itemTypeList.Add(temp);
                }
               itemView.typeinfo = itemTypeList;

                List<CreateItemView> itemStateList = new List<CreateItemView>();
                foreach (STATE i in db.STATEs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.StateID = i.STATEID;
                    temp.State = i.TITLE;
                    itemStateList.Add(temp);
                }
                itemView.stateinfo = itemStateList;

                List<CreateItemView> categoryList = new List<CreateItemView>();
                foreach (CATEGORY c in db.CATEGORies)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.CategoryID = c.CATEGORYID;
                    temp.Category = c.TITLE;
                    categoryList.Add(temp);
                }
                itemView.categoryinfo = categoryList;

                List<CreateItemView> colorList = new List<CreateItemView>();
                foreach (COLOR c in db.COLORs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.ColorID = c.COLORID;
                    temp.Color = c.TITLE;
                    colorList.Add(temp);
                }
                itemView.colorinfo = colorList;

                List<CreateItemView> locationList = new List<CreateItemView>();
                foreach (LOCATION l in db.LOCATIONs)
                {
                    CreateItemView temp = new CreateItemView();
                    temp.LocationID = l.LOCATIONID;
                    temp.Location = l.TITLE;
                    locationList.Add(temp);
                }
                itemView.locationinfo = locationList;
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

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            
            using (lostfoundDB db = new lostfoundDB()) {

                foreach (ITEM item in db.ITEMs)
                {
                    Item temp = new Item();
                    temp.ItemID = item.ITEMID;
                    temp.Reporter = GetData(item.REPORTERID, "reporter");
                    temp.CreatedByName= GetData(item.CREATEDBYID, "user");
                    temp.CreatedDate = item.CREATEDDATE;
                    temp.ItemType = GetData (item.ITEMTYPEID, "type");
                    temp.State = GetData(item.STATEID,"state");
                    temp.FLDate = item.FLDATE;
                    temp.Category = GetData( item.CATEGORYID, "category");
                    temp.Color = item.COLORID;
                    temp.Location = GetData(item.LOCATIONID, "location");
                    temp.Image = item.IMAGE;
                    temp.Notes = item.NOTES;
                    items.Add(temp);
                }
                
            }

            return items;
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

        private string Encrypt(string plainText)
        {

            return Utilities.EncryptText(plainText);
        }


        /*public string GetColor(int? id)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
              
                var color = db.COLORs.Where(o => o.COLORID.Equals(id));
                if (color.Any())
                    return color.FirstOrDefault().TITLE;
                else
                    return string.Empty;
            }
        }*/

        public string GetData(int id, string table)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                var result ="";
                switch(table){
                    case "reporter":
                        var reporter = db.REPORTERs.Where(o => o.REPORTERID.Equals(id));
                        if (reporter.Any())
                            result = reporter.FirstOrDefault().FIRSTNAME + " " + reporter.FirstOrDefault().LASTNAME;
                        break;
                    case "user":
                        var user = db.USERs.Where(o => o.USERID.Equals(id));
                        if (user.Any())
                            result = user.FirstOrDefault().FIRSTNAME + " " + user.FirstOrDefault().LASTNAME;
                        break;

                    case "type":
                        var type = db.ITEMTYPEs.Where(o => o.ITEMTYPEID.Equals(id));
                        if (type.Any())
                            result = type.FirstOrDefault().TITLE;
                        break;

                    case "state":
                        var state = db.STATEs.Where(o => o.STATEID.Equals(id));
                        if (state.Any())
                            result = state.FirstOrDefault().TITLE;
                        break;


                    case "category":
                        var category = db.CATEGORies.Where(o => o.CATEGORYID.Equals(id));
                        if (category.Any())
                            result = category.FirstOrDefault().TITLE;
                        break;

                    case "color":
                        var color = db.COLORs.Where(o => o.COLORID.Equals(id));
                        if (color.Any())
                            result = color.FirstOrDefault().TITLE;
                        break;
                    case "location":
                        var location = db.LOCATIONs.Where(o => o.LOCATIONID.Equals(id));
                        if (location.Any())
                            result = location.FirstOrDefault().TITLE;
                        break;
                }
                return result;
            }
        }
    }
}