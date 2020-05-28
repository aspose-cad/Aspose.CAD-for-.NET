using Aspose.CAD.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.CAD.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "Free Apps to View AutoCAD Files | Convert to PDF or Image format";
			ViewBag.MetaDescription = "Our online 100% free Apps to view AutoCAD (DWG, DXF, DWF, IFC or STL) files from anywhere. Convert to PDF, JPG, PNG, PDFA_1A, PDFA_1B, PDF_15, SVG, BMP, TIFF.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
