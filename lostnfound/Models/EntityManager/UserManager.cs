using System;
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
    }
}