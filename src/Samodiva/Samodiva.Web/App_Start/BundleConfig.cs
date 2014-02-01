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
            bundles.Add(new ScriptBundle("~/js/main")
                .Include("~/Content/js/switcher.js")
                .Include("~/Content/js/scripts.js"));
        }
    }
}