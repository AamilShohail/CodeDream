using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Email.Controllers
{
    public class HomeController : Controller
    {
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            string CountryCodeInUrl = "", redirectUrl = "";
            var countryCode = CookieSettings.ReadCookie();
            if (countryCode == "")
            {
                countryCode = "gb";
            }

            if (System.Web.HttpContext.Current.Request.RawUrl.Length >= 2)
            {
                CountryCodeInUrl = System.Web.HttpContext.Current.Request.RawUrl.Substring(1, 2);
            }

            if (countryCode != CountryCodeInUrl)
            {
                if (System.Web.HttpContext.Current.Request.RawUrl.Length >= 2)
                {
                    if (System.Web.HttpContext.Current.Request.RawUrl.Substring(1, 2) != "")
                    {
                        countryCode = System.Web.HttpContext.Current.Request.RawUrl.Substring(1, 2);
                    }
                }

                if (!System.Web.HttpContext.Current.Request.RawUrl.Contains(countryCode))
                {
                    redirectUrl = string.Format("/{0}{1}", countryCode, System.Web.HttpContext.Current.Request.RawUrl);
                }
                else
                {
                    redirectUrl = System.Web.HttpContext.Current.Request.RawUrl;
                }
                CookieSettings.SaveCookie(countryCode);
                System.Web.HttpContext.Current.Response.RedirectPermanent(redirectUrl);
            }

        }
        public class CookieSettings
        {
            public static void SaveCookie(string data)
            {
                var _CookieValue = new HttpCookie("CountryCookie");
                _CookieValue.Value = data;
                _CookieValue.Expires = DateTime.Now.AddDays(300);
                System.Web.HttpContext.Current.Response.Cookies.Add(_CookieValue);
            }

            public static string ReadCookie()
            {
                var _CookieValue = "";
                if (System.Web.HttpContext.Current.Request.Cookies["CountryCookie"] != null)
                    _CookieValue = System.Web.HttpContext.Current.Request.Cookies["CountryCookie"].Value;
                return _CookieValue;
            }
        }
        public ActionResult CountryCode()
        {
            return View();
        }
        public ActionResult Index()
        {
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