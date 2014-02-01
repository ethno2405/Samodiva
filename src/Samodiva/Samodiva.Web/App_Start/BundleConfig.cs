using System;
using System.Web.Optimization;

namespace Samodiva.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            Scripts(bundles);
        }

        private static void Scripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js")
                //.Include("~/Content/js/jquery.min.js")
                .Include("~/Content/js/switcher.js")
                .Include("~/Content/js/scripts.js"));
        }
    }
}