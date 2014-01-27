using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;

namespace Samodiva.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            Contract.Requires<ArgumentNullException>(filters != null);

            filters.Add(new HandleErrorAttribute());
        }
    }
}