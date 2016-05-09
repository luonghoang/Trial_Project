using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Provider;

namespace Trial.Controllers
{
    public class ProviderFactory : IProviderFactory
    {

        public ProviderFactory()
            : base()
        {

        }

        //Provider
        public IUserProvider User { get { return new UserProvider (this); } }



    }
    public class BaseController : Controller
    {
        private ProviderFactory _providers;
        protected ProviderFactory Providers
        {
            get
            {
                if (_providers == null)
                {
                    _providers = new ProviderFactory();
                }
                return _providers;
            }
        }
        public void Init()
        {
            if (Session["Token"] == null)
            {
                RedirectToAction("Login", "Account");
            }
        }
    }
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var a = Providers.User.GetAccount("luonghoang", "abc123");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}