using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.CAD.Live.Demos.UI.Models
{
	///<Summary>
	/// License class to set apose products license
	///</Summary>
	public static class License
	{
		private static string _licenseFileName = "Aspose.Total.lic";		
		
		///<Summary>
		/// SetAsposeCADLicense method to Aspose.ThreeD License
		///</Summary>
		public static void SetAsposeCADLicense()
		{
			try
			{

				Aspose.CAD.License lic = new Aspose.CAD.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}	
		
	}
}
