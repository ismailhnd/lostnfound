using System;
using System.Linq;
using lostnfound.Models.DB;
using lostnfound.Models.ViewModel;

namespace lostnfound.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(CreateUserView user)
        {

            using (lostfoundDB db = new lostfoundDB())
            {
                USER staff = new USER();
                staff.USERID = user.UserID;
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

        public bool IsEmailExist(string email)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                return db.USERs.Where(o => o.EMAIL.Equals(email)).Any();
            }
        }
    }
}