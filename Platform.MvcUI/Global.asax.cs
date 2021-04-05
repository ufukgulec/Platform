using Platform.Business;
using Platform.Cache;
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
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            CacheProvider.Instance = new DefaultCacheProvider();
            CacheFonksiyon fonksiyon = new CacheFonksiyon();
            fonksiyon.CacheClear();
            fonksiyon.CacheCreate();
        }
    }
}
