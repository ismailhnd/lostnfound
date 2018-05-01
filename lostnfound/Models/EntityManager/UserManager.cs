using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using lostnfound.Models.DB;
using lostnfound.Models.ViewModel;
using lostnfound.Security;

namespace lostnfound.Models.EntityManager
{
    public class UserManager
    {
        /*############################################### Preferences Manager ###############################################*/
        public void CreateAccount(User user)
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

        public void AddColor(Color data)
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

        public void AddLocation(Location data)
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

        public void AddCategory(Category data)
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

        public void AddType(ItemType data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                ITEMTYPE type = new ITEMTYPE
                {
                    TITLE = data.Title
                };
                db.ITEMTYPEs.Add(type);
                db.SaveChanges();
            }
        }

        public void AddState(State data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                STATE state = new STATE
                {
                    TITLE = data.Title
                };
                db.STATEs.Add(state);
                db.SaveChanges();
            }
        }

        public void AddRole(Role data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                ROLE role = new ROLE
                {
                    TITLE = data.Title
                };
                db.ROLEs.Add(role);
                db.SaveChanges();
            }
        }

        /*############################################### Items Manager ###############################################*/

        public void CreateItem(Item data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {

                REPORTER reporter = new REPORTER
                {
                    FIRSTNAME = data.FirstName,
                    LASTNAME = data.LastName,
                    EMAIL = data.Email,
                    PHONENUMBER = data.PhoneNumber,
                    IDDOCUMENT = data.VerificationDocument,
                    AUB = data.AUB
                };
                db.REPORTERs.Add(reporter);

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

        public Item getItem(int? id)
        {
            

            using (lostfoundDB db = new lostfoundDB())
            {
                Item item = new Item();
                ITEM temp = db.ITEMs.Find(id);

                temp.ITEMID = (int) id;
                temp.REPORTERID = item.ReporterID;
                temp.ITEMTYPEID = item.ItemTypeID;
                temp.CREATEDDATE = item.CreatedDate;
                temp.STATEID = item.StateID;
                temp.FLDATE = item.FLDate;
                temp.CATEGORYID = item.CategoryID;
                temp.COLORID = item.ColorID;
                temp.LOCATIONID = item.LocationID;
                temp.IMAGE = item.Image;
                temp.NOTES = item.Notes;
                return item;
            }
                
        }

        public void DeleteItem(int? id)
        {
            using (lostfoundDB db = new lostfoundDB())
            {

                ITEM item = db.ITEMs.Find((int) id);
                db.ITEMs.Remove(item);
                db.SaveChanges();
   
            }

        }



        /*#############################################################################################################*/
        /*#############################################################################################################*/
        /*#############################################################################################################*/


        /*############################################### DDL Manager ###############################################*/
        public User RoleOptions()
        {

            User roleView = new User();
            using (lostfoundDB db = new lostfoundDB())
            {
                List<User> userlist = new List<User>();
                foreach (ROLE r in db.ROLEs)
                {
                    User temp = new User();
                    temp.RoleID = r.ROLEID;
                    temp.Title = r.TITLE;
                    userlist.Add(temp);

                }

                roleView.roleinfo = userlist;
            }
            return roleView;
        }

        public Item ItemOptions()
        {

            Item itemView = new Item();
            using (lostfoundDB db = new lostfoundDB())
            {

                List<Item> userList = new List<Item>();
                foreach (USER i in db.USERs)
                {
                    Item temp = new Item();
                    temp.CreatedByID = i.USERID;
                    temp.fname = i.FIRSTNAME;
                    userList.Add(temp);
                }
                itemView.userinfo = userList;

                List<Item> itemTypeList = new List<Item>();
                foreach (ITEMTYPE i in db.ITEMTYPEs)
                {
                    Item temp = new Item();
                    temp.ItemTypeID = i.ITEMTYPEID;
                    temp.Type = i.TITLE;
                    itemTypeList.Add(temp);
                }
               itemView.typeinfo = itemTypeList;

                List<Item> itemStateList = new List<Item>();
                foreach (STATE i in db.STATEs)
                {
                    Item temp = new Item();
                    temp.StateID = i.STATEID;
                    temp.State = i.TITLE;
                    itemStateList.Add(temp);
                }
                itemView.stateinfo = itemStateList;

                List<Item> categoryList = new List<Item>();
                foreach (CATEGORY c in db.CATEGORies)
                {
                    Item temp = new Item();
                    temp.CategoryID = c.CATEGORYID;
                    temp.Category = c.TITLE;
                    categoryList.Add(temp);
                }
                itemView.categoryinfo = categoryList;

                List<Item> colorList = new List<Item>();
                foreach (COLOR c in db.COLORs)
                {
                    Item temp = new Item();
                    temp.ColorID = c.COLORID;
                    temp.Color = c.TITLE;
                    colorList.Add(temp);
                }
                itemView.colorinfo = colorList;

                List<Item> locationList = new List<Item>();
                foreach (LOCATION l in db.LOCATIONs)
                {
                    Item temp = new Item();
                    temp.LocationID = l.LOCATIONID;
                    temp.Location = l.TITLE;
                    locationList.Add(temp);
                }
                itemView.locationinfo = locationList;
            }
            return itemView;
        }

        /*############################################### Helper Methods Manager ###############################################*/
        public bool IsEmailExist(string email)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                return db.USERs.Where(o => o.EMAIL.Equals(email)).Any();
            }
        }

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

        public List<Items> GetItems()
        {
            List<Items> items = new List<Items>();
            
            using (lostfoundDB db = new lostfoundDB()) {

                foreach (ITEM item in db.ITEMs)
                {
                    Items temp = new Items();
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

        /*############################################### Private Helper Methods Manager ###############################################*/
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

        private string GetData(int id, string table)
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