using System.Web;
using System.Web.Mvc;

namespace IDGS903_Espinosa_Jesus_Examen1P
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
