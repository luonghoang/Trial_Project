using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Trial.Models;

namespace Trial.Ultils
{
    public static class MethodExt
    {
        public static void SetSession(this HttpSessionState session,string sessionName, object data)
        {
            session[sessionName] = data;
        }
        public static LoginViewModel GetCurrentUser(this HttpSessionStateBase session)
        {
            return UserLogin.GetCurrentUser;
        }
    }
}