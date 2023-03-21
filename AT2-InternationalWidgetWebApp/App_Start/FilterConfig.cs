using System.Web;
using System.Web.Mvc;

namespace AT2_InternationalWidgetWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
