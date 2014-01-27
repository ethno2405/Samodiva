using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcPaging;
using Samodiva.Web.Areas.Admin.Models.News;
using Samodiva.Web.DataAccess;

namespace Samodiva.Web.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        public ActionResult Index(int pageSize = 10, int page = 1)
        {
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 1 : pageSize;

            IList<News> news;
            using (var context = new SamodivaDBEntities())
            {
                news = context.Set<News>().OrderByDescending(x => x.Date).ToList(); // TODO cache
            }

            var model = new List<NewsModel>();

            foreach (var item in news)
            {
                model.Add(new NewsModel
                {
                    Id = item.id,
                    Title = item.Title,
                    Date = item.Date
                });
            }

            return View(model.ToPagedList(page, pageSize));
        }

        public ActionResult Preview(int id)
        {
            return View();
        }
    }
}