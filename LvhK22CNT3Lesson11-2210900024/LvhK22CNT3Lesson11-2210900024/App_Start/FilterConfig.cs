using System.Web;
using System.Web.Mvc;

namespace LvhK22CNT3Lesson11_2210900024
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
