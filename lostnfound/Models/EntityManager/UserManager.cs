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
                    USERID = UniqueID("User"),
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
                    REPORTERID = UniqueID("Reporter"),
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
        //TODO: check id fetching and foreign keys
        public void AddItem(CreateItemView data)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                ITEM item = new ITEM
                {
                    ITEMID = UniqueID("Item"),
                    REPORTERID = data.ReporterID,
                    CREATEDBYID = data.CreatedByID,
                    CREATEDDATE = data.CreatedDate,
                    ITEMTYPEID = data.ItemTypeID,
                    STATEID = data.StateID,
                    FLDATE = data.FLDateID,
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
                    COLORID = UniqueID("Color"),
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
                    LOCATIONID = UniqueID("Location"),
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
                    CATEGORYID = UniqueID("Category"),
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
        public List<ROLE> GetAllRoles()
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                var roles = db.ROLEs.Select(o=> new ROLE
                {
                    ROLEID = o.ROLEID,
                    TITLE = o.TITLE
                }).ToList();

                return roles;
            }
        }
        public int GetUserID(string loginName)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                var user = db.USERs.Where(o=> o.EMAIL.Equals(loginName));
                if (user.Any()) return user.FirstOrDefault().USERID;
            }
            return 0;
        }
        public List<CreateUserView> GetAllUserProfiles()
        {
            List<CreateUserView> profiles = new List<CreateUserView>();

            using (lostfoundDB db = new lostfoundDB())
            {
                CreateUserView UPV;
                var users = db.USERs.ToList();

                foreach (USER u in db.USERs)
                {
                    UPV = new CreateUserView();
                    UPV.UserID = u.USERID;
                    UPV.Email = u.EMAIL;
                    UPV.Password = u.PASSWORD;
                    UPV.FirstName = u.FIRSTNAME;
                    UPV.LastName = u.LASTNAME;
                    
                    UPV.RoleID = u.ROLEID;
                    // UPV.roleinfo = new List<ROLE> u.ROLE;
                    var SUP = db.USERs.Find(u.USERID);
                    if (SUP != null)
                    {
                        UPV.FirstName = SUP.FIRSTNAME;
                        UPV.LastName = SUP.LASTNAME;
                        UPV.PhoneNumber = SUP.PHONENUMBER;
                        //UPV.Gender = SUP.Gender;
                    }


                    var SUR = db.ROLEs.Where(o=> o.ROLEID.Equals(u.ROLEID));
                    if (SUR.Any())
                    {
                        var userRole = SUR.FirstOrDefault();
                        UPV.RoleID = userRole.ROLEID;
                        UPV.Title = userRole.TITLE;
                    }

                    profiles.Add(UPV);
                }
            }

            return profiles;
        }
        /*public CreateUserView GetUserDataView(string loginName)
        {
            CreateUserView UDV = new CreateUserView();
            List<CreateUserView> profiles = GetAllUserProfiles();
            List<ROLE> roles = GetAllRoles();

            int? userAssignedRoleID = 0,
             userID = 0;

            userID = GetUserID(loginName);
            using (lostfoundDB db = new lostfoundDB())
            {
                userAssignedRoleID = db.ROLEs.Where(o=> o.ROLEID == userID)?.FirstOrDefault().ROLEID;
                userID = db.USERs.Where(o=> o.USERID == userID)?.FirstOrDefault().USERID;
            }

            List<int> userIDs = new List<int>();
            userIDs.Add(new Gender
            {
                Text = "Male",
                Value = "M"
            });
            genders.Add(new Gender
            {
                Text = "Female",
                Value = "F"
            });

            UDV.UserProfile = profiles;
            UDV.UserRoles = new UserRoles
            {
                SelectedRoleID = userAssignedRoleID,
                UserRoleList = roles
            };

            UDV.UserGender = new UserGender
            {
                SelectedGender = userGender,
                Gender = genders
            };

            return UDV;
        }*/

    }
}