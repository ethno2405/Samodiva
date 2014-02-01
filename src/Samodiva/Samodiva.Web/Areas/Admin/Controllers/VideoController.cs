using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Samodiva.Web.Areas.Admin.Models.Gallery;
using Samodiva.Web.DataAccess;
using YoutubeExtractor;

namespace Samodiva.Web.Areas.Admin.Controllers
{
    public class VideoController : BaseController
    {
        public ActionResult Videos(int pageSize = 10, int page = 1)
        {
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 1 : pageSize;

            IList<Video> videos;
            using (var context = new SamodivaDBEntities())
            {
                videos = context.Set<Video>().OrderByDescending(x => x.Date).Skip(page * pageSize).Take(pageSize).ToList();
            }

            var model = new List<VideoModel>();

            foreach (var item in videos)
            {
                model.Add(new VideoModel
                {
                    Id = item.Id,
                    Date = item.Date,
                    Description = item.Description,
                    ThumbUrl = item.ThumbURL,
                    Title = item.Title,
                    Url = item.URL
                });
            }

            return PartialView("~/Areas/Admin/Views/Gallery/Video/Videos.cshtml", model);
        }

        public ActionResult Preview(int id)
        {
            Video video;
            using (var context = new SamodivaDBEntities())
            {
                video = context.Set<Video>().FirstOrDefault(x => x.Id == id);
            }

            if (video == null)
            {
                return HttpNotFound();
            }

            var url = DownloadUrlResolver.GetDownloadUrls(video.URL).OrderByDescending(x => x.AudioBitrate).First().DownloadUrl;
            var model = new VideoModel
            {
                Id = video.Id,
                Date = video.Date,
                Description = video.Description,
                Title = video.Title,
                Url = video.URL,
                DownloadUrl = url
            };

            return View("~/Areas/Admin/Views/Gallery/Video/Preview.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(VideoModel model)
        {
            Video video;
            using (var context = new SamodivaDBEntities())
            {
                video = context.Set<Video>().FirstOrDefault(x => x.Id == model.Id);

                if (video == null)
                {
                    return HttpBadRequest();
                }

                video.Description = model.Description;
                video.Title = model.Title;
                video.URL = model.Url; // TODO change thumbnail

                context.SaveChanges();
            }

            return RedirectToAction("Index", "Gallery");
        }
    }
}
