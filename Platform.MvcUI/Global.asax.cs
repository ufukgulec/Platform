using Platform.Business;
using Platform.Cache;
using Platform.MvcUI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Platform.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());//Tüm uygulamada Authorize
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            CacheProvider.Instance = new DefaultCacheProvider();
            CacheFonksiyon fonksiyon = new CacheFonksiyon();
            fonksiyon.CacheClear();
            fonksiyon.CacheCreate();

        }
    }
}
