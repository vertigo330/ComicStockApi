﻿using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ComicStock.API
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			GlobalConfiguration.Configuration.Formatters.Clear();
			GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
			GlobalConfiguration.Configuration.Formatters.Add(new XmlMediaTypeFormatter());

			DataCache.Initialise();
		}

		
	}
}