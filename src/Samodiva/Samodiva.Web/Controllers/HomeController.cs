using System.Linq;
using System.Net;
using System.Web.Mvc;
using Samodiva.Web.DataAccess;

namespace Samodiva.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetContent()
        //{
        //    var context = new SamodivaDBEntities();
        //    var dbSet = context.Set<Participant>().Select(x => x.Image_URL).ToList();

        //    using (var client = new WebClient())
        //    {
        //        foreach (var item in dbSet)
        //        {
        //            var url = string.Format("http://samodivabg.com/img/thebest/{0}", item);
        //            var urlThumb = string.Format("http://samodivabg.com/img/thebest/thumbnails/{0}", item);

        //            var destination = string.Format(@"D:\My Documents\Visual Studio 2012\Projects\Samodiva\data\Img\TheBest\{0}", item);
        //            var destinationThumb = string.Format(@"D:\My Documents\Visual Studio 2012\Projects\Samodiva\data\Img\TheBest\Thumbnails\{0}", item);

        //            client.DownloadFile(url, destination);
        //            client.DownloadFile(urlThumb, destinationThumb);
        //        }
        //    }

        //    return View();
        //}
    }
}