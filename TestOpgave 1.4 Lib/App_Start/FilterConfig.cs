using System.Web;
using System.Web.Mvc;

namespace TestOpgave_1._4_Lib
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
