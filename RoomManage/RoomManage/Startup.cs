using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RoomManage.Models;

[assembly: OwinStartupAttribute(typeof(RoomManage.Startup))]
namespace RoomManage
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createDefaultRoleAndUser();
        }
        public void createDefaultRoleAndUser()
        {
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!rolemanager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                rolemanager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "khalid hussein";
                user.Email = "khalid0966303644@gmail.com";
                var check = usermanager.Create(user, "Kh#786");
                if (check.Succeeded)
                {
                    usermanager.AddToRole(user.Id, "Admins");
                }
            }
        }
    }
}
