using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Aug2015Backend.App_Start
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}