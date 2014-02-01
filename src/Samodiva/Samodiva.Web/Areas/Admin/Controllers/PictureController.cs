using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Samodiva.Web.Areas.Admin.Models.Gallery;
using Samodiva.Web.DataAccess;

namespace Samodiva.Web.Areas.Admin.Controllers
{
    public class PictureController : BaseController
    {
        public ActionResult Pictures(int pageSize = 10, int page = 1)
        {
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 1 : pageSize;

            IList<Picture> videos;
            using (var context = new SamodivaDBEntities())
            {
                videos = context.Set<Picture>().OrderByDescending(x => x.Date).Skip(page * pageSize).Take(pageSize).ToList();
            }

            var model = new List<PictureModel>();

            foreach (var item in videos)
            {
                model.Add(new PictureModel
                {
                    Id = item.Id,
                    Date = item.Date,
                    Description = item.Description,
                    Title = item.Title,
                    FileName = item.URL
                });
            }

            return PartialView("~/Areas/Admin/Views/Gallery/Picture/Pictures.cshtml", model);
        }

        public ActionResult Preview(int id)
        {
            Picture picture;
            using (var context = new SamodivaDBEntities())
            {
                picture = context.Set<Picture>().FirstOrDefault(x => x.Id == id);
            }

            if (picture == null)
            {
                return HttpNotFound();
            }

            var model = new PictureModel
            {
                Id = picture.Id,
                Title = picture.Title,
                FileName = picture.URL,
                Description = picture.Description,
                Date = picture.Date
            };

            return View("~/Areas/Admin/Views/Gallery/Picture/Preview.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(PictureModel model)
        {
            Picture picture;
            using (var context = new SamodivaDBEntities())
            {
                picture = context.Set<Picture>().FirstOrDefault(x => x.Id == model.Id);

                if (picture == null)
                {
                    return HttpBadRequest();
                }

                picture.Title = model.Title;
                picture.Description = model.Description;

                context.SaveChanges();
            }

            return RedirectToAction("Index", "Gallery");
        }
    }
}
