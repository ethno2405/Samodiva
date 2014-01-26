using System.Web.Mvc;
using Samodiva.Common;

namespace Samodiva.Web.Controllers
{
    public class BaseController : Controller
    {
        private static Logger logger;

        protected override void OnException(ExceptionContext filterContext)
        {
            logger = logger ?? new Logger(GetType());
            logger.LogException(filterContext.Exception);
        }
    }
}