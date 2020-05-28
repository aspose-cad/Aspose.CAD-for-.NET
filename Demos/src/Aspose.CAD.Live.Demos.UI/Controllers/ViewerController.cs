using Aspose.CAD.Live.Demos.UI.Models.Common;
using Aspose.CAD.Live.Demos.UI.Models;
using Aspose.CAD.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace Aspose.CAD.Live.Demos.UI.Controllers
{
	public class ViewerController : BaseController
	{
		public override string Product => (string)RouteData.Values["product"];


		
		


			public ActionResult Viewer()
		{
			var model = new ViewModel(this, "Viewer")
			{				
				MaximumUploadFiles = 1,				
				
				UploadAndRedirect = true
			};
			if (model.RedirectToMainApp)
				return Redirect("/psd/" + model.AppName.ToLower());
			return View(model);		
			
		}	

	}
}
