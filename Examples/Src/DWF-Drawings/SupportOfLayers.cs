using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DWF_Drawings
{
	class SupportOfLayers
	{
		public static void Run()
		{
			//ExStart:SupportOfLayers
			// The path to the documents directory.
			string MyDir = RunExamples.GetDataDir_DXFDrawings();
			string sourceFilePath = MyDir + "for_layers_test.dwf";
			using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(sourceFilePath))
			{
				//  Create an instance of CadRasterizationOptions and set its various properties
				Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
				rasterizationOptions.PageWidth = 1600;
				rasterizationOptions.PageHeight = 1600;

				// Add desired layers
				rasterizationOptions.Layers= new string[] { "LayerA" };
				
				

				JpegOptions jpegOptions = new JpegOptions();
				jpegOptions.VectorRasterizationOptions = rasterizationOptions;

				MyDir = MyDir + "for_layers_test.jpg";
				// Export the DXF to JPG
				image.Save(MyDir, jpegOptions);
			}
			//ExEnd:SupportOfLayers


		}
	}
}