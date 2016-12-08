using System.Web;
using System.Web.Mvc;

namespace Student_FAQ_BYUIS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
