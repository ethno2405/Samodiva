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
            bundles.Add(new ScriptBundle("~/Content/js/jquery").Include("~/Content/js/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/Content/js/switcher").Include("~/Content/js/switcher.js"));
            bundles.Add(new ScriptBundle("~/Content/js/scripts").Include("~/Content/js/scripts.js"));
        }
    }
}