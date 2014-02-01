using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Samodiva.Web.Areas.Admin.Models.News;
using Samodiva.Web.DataAccess;

namespace Samodiva.Web.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        public ActionResult Index(int pageSize = 10, int page = 1) // TODO paging, select all, attaching images to news, dynamic query
        {
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 1 : pageSize;

            IList<News> news;
            using (var context = new SamodivaDBEntities())
            {
                news = context.Set<News>().OrderByDescending(x => x.Date).Skip(page * pageSize).Take(pageSize).ToList();
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

            return View(model);
        }

        public ActionResult Preview(int id)
        {
            News news;
            using (var context = new SamodivaDBEntities())
            {
                news = context.Set<News>().FirstOrDefault(x => x.id == id);    
            }

            if (news == null)
            {
                return HttpNotFound();
            }

            var model = new NewsModel
            {
                Id = news.id,
                Title = news.Title,
                Date = news.Date,
                Body = news.Body
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(NewsModel editedNews)
        {
            using (var context = new SamodivaDBEntities())
            {
                var news = context.Set<News>().FirstOrDefault(x => x.id == editedNews.Id);
                if (news == null)
                {
                    return HttpBadRequest();
                }

                news.Title = editedNews.Title;
                news.Body = editedNews.Body;

                context.SaveChanges();
            }

            return RedirectToAction("index", "news");
        }
    }
}