using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Trial.Models;

namespace Trial.Ultils
{
    public class UserLogin
    {
        public static bool SetCookies(object userid, HttpResponseBase Response, bool remember)
        {
            try
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(userid.ToString(), remember, 1200);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                cookie.Expires = authTicket.Expiration;
                Response.Cookies.Set(cookie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsLogin
        {
            get
            {
                try
                {
                    return GetUserID > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static int GetUserID
        {
            get
            {
                try
                {
                    var data = HttpContext.Current.User.Identity.Name.ToString();
                    return Convert.ToInt32(data.Split('_')[0]);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }


        public static int? GetOrgID
        {
            get
            {
                try
                {
                    var data = HttpContext.Current.User.Identity.Name.ToString();
                    return Convert.ToInt32(data.Split('_')[1]);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public static string GetUserName
        {
            get
            {
                try
                {
                    //return GetCurrentUser.UserName;
                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }


        public static LoginViewModel GetCurrentUser
        {
            get
            {
                try
                {
                    var username = GetUserID;
                    if (username <= 0) return null;
                    else
                    {
                       // call to get user.
                        //return proxy.GetById_tbUsers_Proxy(username).ToObject<tbUsers>();
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

    }
}