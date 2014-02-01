using System;
using System.Collections.Generic;

namespace Samodiva.Web.Areas.Admin.Models.News
{
    public class NewsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }
    }
}