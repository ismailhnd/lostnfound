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

                
                staff.USERID = UniqueID();
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

        public void AddReporterAccount(CreateReporterView user)
        {

            using (lostfoundDB db = new lostfoundDB())
            {
                REPORTER staff = new REPORTER();


                staff.REPORTERID = UniqueID();
                staff.FIRSTNAME = user.FirstName;
                staff.LASTNAME = user.LastName;
                staff.EMAIL = user.Email;
                staff.PHONENUMBER = user.PhoneNumber;
                staff.IDDOCUMENT = user.VerificationDocument;
                staff.AUB = user.AUB;
               //AUB should be yes or no
                db.REPORTERs.Add(staff);
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


        public bool IsIDExist(int id)
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                return db.REPORTERs.Where(o => o.REPORTERID.Equals(id)).Any();
            }
        }

        public int UniqueID()
        {
            Random rnd = new Random();
            int unique = rnd.Next(1, 1000);

            if (IsIDExist(unique))
            {
                return UniqueID();
            }
            else
            {
                return unique;
            }
        }
    }

    
}