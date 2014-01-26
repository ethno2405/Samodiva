using System;
using System.Web.Mvc;

namespace Samodiva.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}