using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using LoginAssignment.Models;
using Microsoft.Owin.Security.DataProtection;


namespace LoginAssignment.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

        public SignInManager<IdentityUser, string> SignInManager => HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var signInStatus = await SignInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

                switch (signInStatus)
                {
                    case SignInStatus.Success:
                        return RedirectToAction("Index", "Home");
                    default:
                        ModelState.AddModelError("", "Invalid Credentials");
                        return View(model);
                }
            }
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await UserManager.FindByNameAsync(model.Username);
                if (identityUser != null)
                {
                    ModelState.AddModelError("", "");
                    //return RedirectToAction("Index", "Home");
                }

                var identityResult = await UserManager.CreateAsync(new IdentityUser(model.Username), model.Password);
                if (identityResult.Succeeded)
                {
                    
                    Console.WriteLine("User Registration was successful");
                    return RedirectToAction("Login", "Account");
                }
                Console.WriteLine("User Registration was not successful");
                ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());
                return View(model);
            }
            return View();
              
        }

        public ActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> PasswordReset(PasswordResetModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Username);
                if (user == null)
                {                    // Don't reveal that the user does not exist or is not confirmed
                    return View("PasswordReset");
                }
                if (model.NewPassword != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Passwords do not match");
                    return View("PasswordReset");
                }
                bool isValidPassword =  UserManager.CheckPassword(user,model.CurrentPassword);
                //IdentityResult validatePasswordResult = await UserManager.PasswordValidator<IdentityUser>().ValidateAsync(model.CurrentPassword);

                if (isValidPassword)
                {
                    var provider = new DpapiDataProtectionProvider("SampleAppName");
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(
                        provider.Create("UserToken"));
                    string resetToken = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    IdentityResult passwordChangeResult = await UserManager.ResetPasswordAsync(user.Id, resetToken, model.NewPassword);
                
               

                if (passwordChangeResult.Succeeded)
                {
                    return View("~/Views/ResetPassword/ResetPasswordConfirmation.cshtml");
                }
                else
                {
                    ModelState.AddModelError("", "Could not Reset Password");
                    return View("PasswordReset");
                }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Password");
                    return View("PasswordReset");
                }

               
            }

            // If we got this far, something failed, redisplay form
            return View(model);
            
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Username);
                if (user == null)
                {                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPassword");
                }
                if (model.NewPassword != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Passwords do not match");
                    return View("ForgotPassword");
                }
               
                    var provider = new DpapiDataProtectionProvider("SampleAppName");
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(
                        provider.Create("UserToken"));
                    string resetToken = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    IdentityResult passwordChangeResult = await UserManager.ResetPasswordAsync(user.Id, resetToken, model.NewPassword);



                    if (passwordChangeResult.Succeeded)
                    {
                        return View("~/Views/ResetPassword/ResetPasswordConfirmation.cshtml");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Could not Reset Password");
                        return View("ForgotPassword");
                    }
                
               

                // If we got this far, something failed, redisplay form
                //return View(model);
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();  
        }
    }
}