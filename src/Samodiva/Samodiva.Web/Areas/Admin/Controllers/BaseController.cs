using System.Net;
using System.Web.Mvc;
using Samodiva.Common;

namespace Samodiva.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        private static Logger logger;

        protected override void OnException(ExceptionContext filterContext)
        {
            logger = logger ?? new Logger(GetType());
            logger.LogException(filterContext.Exception);
        }

        protected ActionResult HttpBadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}