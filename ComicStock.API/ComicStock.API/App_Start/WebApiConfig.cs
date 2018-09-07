using System.Web.Http;
using System.Web.Http.Cors;

namespace ComicStock.API
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();
		}
	}
}
