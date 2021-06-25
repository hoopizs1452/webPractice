using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace cloudHW03Web
{
    public class WebApiConfig
    {
        // set the baseurl of the WebApis:
        // if WebApis are on localhost,     baseurl = "http://localhost:4438/"  
        // if WebApis are on my cloud VM, baseurl = "http://140.137.41.136:1380/a1234567/MathWebApis/"
        //public static string baseurl = "http://localhost:4438/";
        public static string baseurl = "http://140.137.41.136:1380/A7407630/cloudHW03API/";

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}