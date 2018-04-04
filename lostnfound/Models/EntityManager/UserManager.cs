using System;
using System.Linq;
using lostnfound.Models.DB;
using lostnfound.Models.ViewModel;
using System.Collections.Generic;

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
                USER staff = new USER();

                staff.USERID = UniqueID("User");
                staff.FIRSTNAME = user.FirstName;
                staff.LASTNAME = user.LastName;
                staff.EMAIL = user.Email;
                staff.PHONENUMBER = user.PhoneNumber;
                staff.PASSWORD = user.Passowrd;
                staff.FIRSTNAME = user.FirstName;
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
                REPORTER staff = new REPORTER();

                staff.REPORTERID = UniqueID("Reporter");
                staff.FIRSTNAME = user.FirstName;
                staff.LASTNAME = user.LastName;
                staff.EMAIL = user.Email;
                staff.PHONENUMBER = user.PhoneNumber;
                staff.IDDOCUMENT = user.VerificationDocument;
                staff.AUB = user.AUB;
                db.REPORTERs.Add(staff);
                db.SaveChanges();
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
                else
                {
                    return false;
                }

            }
        }
        //*******NEW*****  
        
        public List<LookUpAvailableRole> GetAllRoles()
        {
            using (lostfoundDB db = new lostfoundDB() )
            {
                var roles = db.ROLEs.Select(o => new LookUpAvailableRole
                {
                    ROLEID = o.ROLEID,
                    TITLE = o.TITLE,

                }).ToList();

                return roles;
            }
        }

        public int GetUserID(string loginName)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                var user = db.USERs.Where(o => o.EMAIL.Equals(loginName));
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
                    UPV.Passowrd = u.PASSWORD;

                    var SUP = db.USERs.Find(u.USERID);
                    if (SUP != null)
                    {
                        UPV.FirstName = SUP.FIRSTNAME;
                        UPV.LastName = SUP.LASTNAME;
                        //UPV.ROLEID = SUP.ROLEID;
                        UPV.PhoneNumber = SUP.PHONENUMBER;
                        
                    }

                    var SUR = db.USERs.Where(o => o.USERID.Equals(u.USERID));
                    if (SUR.Any())
                    {
                        var userRole = SUR.FirstOrDefault();
                        UPV.ROLEID = userRole.ROLEID;
                        UPV.ROLE = userRole.ROLE;
                        //UPV.r = userRole.IsActive;
                    }

                    profiles.Add(UPV);
                }
            }

            return profiles;
        }

        public UserManager GetUserDataView(string loginName)
        {
            UserManager UDV = new UserManager();
            List<USER> profiles = GetAllUserProfiles();
            List<ROLE> roles = GetAllRoles();

            int? userAssignedRoleID = 0, userID = 0;
           // string userGender = string.Empty;

            userID = GetUserID(loginName);
            using (lostfoundDB db = new lostfoundDB())
            {
                userAssignedRoleID = db.USERs.Where(o => o.USERID == userID)?.FirstOrDefault().ROLEID;
                
               // userGender = db.USERs.Where(o => o.USERID == userID)?.FirstOrDefault().Gender;
            }

           /* List<Gender> genders = new List<Gender>();
            genders.Add(new Gender
            {
                Text = "Male",
                Value = "M"
            });
            genders.Add(new Gender
            {
                Text = "Female",
                Value = "F"
            });*/

            UDV.UserProfile = profiles;
            UDV.UserRoles = new UserRoles
            {
                SelectedRoleID = userAssignedRoleID,
                UserRoleList = roles
            };

           /* UDV.UserGender = new UserGender
            {
                SelectedGender = userGender,
                Gender = genders
            };*/

            return UDV;
        }

    }


}