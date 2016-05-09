using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trial.Ultils
{
    public class LinkInfo
    {
        public static void GoToLogin(HttpResponse response, string link)
        {
            try
            {
                response.Redirect(link);
            }
            catch (Exception)
            {

            }
        }
        public static void GoToLogin(HttpResponse response)
        {
            try
            {
                GoToLogin(response, "~/Account/Login.aspx");
            }
            catch (Exception)
            {

            }
        }
    }
}