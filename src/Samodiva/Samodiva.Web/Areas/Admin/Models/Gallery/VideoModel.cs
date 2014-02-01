using System;

namespace Samodiva.Web.Areas.Admin.Models.Gallery
{
    public class VideoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string DownloadUrl { get; set; }

        public string ThumbUrl { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}