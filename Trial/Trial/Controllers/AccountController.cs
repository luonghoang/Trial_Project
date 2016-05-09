using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Trial.Models;
using System.Text;
using System.Security.Cryptography;
using Trial.Ultils;
using Contract.Account.Record;

namespace Trial.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {

     

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid )
            {
                UserRecord user = Providers.User.GetAccount(model.UserName, model.Password);
                if (user != null)
                {
                    string token = CreateRandomCode();

                    //TO DO: Find user by user name, user id.
                    UserLogin.SetCookies(user.User_Id, HttpContext.Response, true);

                    // TO DO: Add token cookies
                    HttpCookie tokenCookie = new HttpCookie("Token", token);
                    tokenCookie.Expires = DateTime.Now.AddDays(1d);
                    Response.Cookies.Add(tokenCookie);

                    //TO DO: Add session
                    Session["User"] = user;
                    Session["Token"] = token;
                    Session["UserID"] = user.User_Id;
                    Session["UserName"] = user.User_Name;

                    return RedirectToAction("Index", "Menu");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private UserRecord getUserLogin(string userName, string password)
        {
            return Providers.User.GetAccount(userName, password);
        }
        public static string CreateRandomCode()
        {
            Random rand = new Random(DateTime.Now.TimeOfDay.Milliseconds);
            string currentDate = DateTime.Now.ToString("ddMMyyyyhh:mm:ss:tt")+rand.Next();
            return EncryptData.Encryption(currentDate);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }


        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}