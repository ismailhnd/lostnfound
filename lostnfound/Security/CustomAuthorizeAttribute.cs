using System.Web;
using System.Web.Mvc;
using lostnfound.Models.DB;
using lostnfound.Models.EntityManager;

namespace lostnfound.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.userAssignedRoles = roles;
        }

        /********************  Authorization Methods ********************/

        //Authorize Core filter 
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            using (lostfoundDB db = new lostfoundDB())
            {
                UserManager UM = new UserManager();
                foreach (var roles in userAssignedRoles)
                {
                    authorize = UM.IsUserInRole(httpContext.User.Identity.Name, roles);
                    if (authorize)
                        return authorize;
                }
            }
            return authorize;
        }

        //Unauthorized  Access Handler
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/Unauthorized");
        }
    }
}