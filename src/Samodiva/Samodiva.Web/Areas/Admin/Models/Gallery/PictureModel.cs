using System;
using System.Web;
using Samodiva.Common;

namespace Samodiva.Web.Areas.Admin.Models.Gallery
{
    public class PictureModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }

        public string ThumbnailUrl
        {
            get
            {
                return string.Format("/{0}/{1}", Configuration.Current.PicturesDirectoryThumbnails, FileName);
            }
        }

        public string Url
        {
            get
            {
                return string.Format("/{0}/{1}", Configuration.Current.PicturesDirectory, FileName);
            }
        }
    }
}