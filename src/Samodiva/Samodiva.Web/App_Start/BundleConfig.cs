using System;
using System.Diagnostics.Contracts;
using System.Web.Optimization;

namespace Samodiva.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            Contract.Requires<ArgumentNullException>(bundles != null);

            Css(bundles);
            Scripts(bundles);
        }

        private static void Scripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js")
                .Include("~/Content/js/jquery.min.js")
                .Include("~/Content/js/switcher.js")
                .Include("~/Content/js/scripts.js"));

            bundles.Add(new ScriptBundle("~/Content/js/backend")
                .Include("~/Content/js/bootstrap.js")
                //.Include("~/Content/js/jquery-2.1.0.js")
                .Include("~/Content/js/jquery-1.8.3.js")
                .Include("~/Content/js/jquery.unobtrusive-ajax.js")
                .Include("~/Content/js/jquery.validate.js")
                .Include("~/Content/js/jquery.validate.unobtrusive-custom-for-bootstrap.js")
                .Include("~/Content/js/jquery.validate.unobtrusive.js"));
        }

        private static void Css(BundleCollection bungles)
        {
            bungles.Add(new StyleBundle("~/Content/css/backend")
                .Include("~/Content/css/paging.css")
                .Include("~/Content/css/bootstrap.css")
                .Include("~/Content/css/bootstrap-responsive.css")
                .Include("~/Content/css/bootstrap-mvc-validation.css"));
        }
    }
}