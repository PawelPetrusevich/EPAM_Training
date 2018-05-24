using System.Web;
using System.Web.Mvc;

namespace Bank.MVC.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Bank.Common.DTO;
    using Bank.MVC.Identity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    public class AccountController : Controller
    {
        private IdentityUserManager UserManager => this.HttpContext.GetOwinContext().GetUserManager<IdentityUserManager>();

        private IAuthenticationManager AuthenticationManager => this.HttpContext.GetOwinContext().Authentication;

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserRegisterDto user)
        {
            if (this.ModelState.IsValid)
            {
                var createdUser = new UserIdentity { UserName = user.Login, Email = user.Email };
                var result = await this.UserManager.CreateAsync(createdUser, user.Password);
                if (result.Succeeded)
                {
                    // return this.View(user);
                    return this.RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var resultError in result.Errors)
                    {
                        this.ModelState.AddModelError(" ", resultError);
                    }
                }
            }

            return this.View(user);
        }

        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginDto user)
        {
            if (this.ModelState.IsValid)
            {
                var userInfo = await this.UserManager.FindAsync(user.Login, user.Password);

                if (userInfo == null)
                {
                    this.ModelState.AddModelError(" ", $@"Incorect login or password");
                }
                else
                {
                    ClaimsIdentity claim = await this.UserManager.CreateIdentityAsync(
                                               userInfo,
                                               DefaultAuthenticationTypes.ApplicationCookie);
                    this.AuthenticationManager.SignOut();
                    this.AuthenticationManager.SignIn(
                        new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, 
                        claim);
                    return this.RedirectToAction("Index", "Home");
                }
            }

            return this.View(user);
        }

        public ActionResult Logaut()
        {
            this.AuthenticationManager.SignOut();
            return this.RedirectToAction("Login");
        }
    }
}