using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using Aspose.CAD.Live.Demos.UI.Config;


namespace Aspose.CAD.Live.Demos.UI
{
	public class Global : HttpApplication
	{
		
		protected void Application_Error(object sender, EventArgs e)
		{			
			
		}

		void Application_Start(object sender, EventArgs e)
		{

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);			
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			RegisterCustomRoutes(RouteTable.Routes);

		}
		void Session_Start(object sender, EventArgs e)
		{
			//Check URL to set language resource file
			string _language = "EN";
			
			SetResourceFile(_language);
		}

		private void SetResourceFile(string strLanguage)
		{
			if (Session["AsposeCADResources"] == null)
				Session["AsposeCADResources"] = new GlobalAppHelper(HttpContext.Current, Application, Configuration.ResourceFileSessionName, strLanguage);
		}

		void RegisterCustomRoutes(RouteCollection routes)
		{
			routes.RouteExistingFiles = true;
			routes.Ignore("{resource}.axd/{*pathInfo}");
					

			routes.MapRoute(
				name: "Default",
				url: "Default",
				defaults: new { controller = "Home", action = "Default" }
			);
			
			routes.MapRoute(
				"AsposeConversionRoute",
				"{product}/Conversion",
				 new { controller = "Conversion", action = "Conversion" }
			);
			routes.MapRoute(
				"DownloadFileRoute",
				"common/download",
				new { controller = "Common", action = "DownloadFile" }
				
				
			);
			routes.MapRoute(
				"UploadFileRoute",
				"common/uploadfile",
				new { controller = "Common", action = "UploadFile" }

			);
			routes.MapPageRoute(
			  "AsposeCADDefaultViewerRoute",
			  "cad/view",
			  "~/ViewerApp/Default.aspx"
			);
			routes.MapRoute(
				"AsposeCADViewerRoute",
				"{product}/viewer",
				 new { controller = "Viewer", action = "Viewer" }
			);


		}

		
	}
}
