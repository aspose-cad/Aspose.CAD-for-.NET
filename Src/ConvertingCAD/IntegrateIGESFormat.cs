using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
	class IntegrateIGESFormat
	{
		public static void Run()
		{
			//ExStart:IntegrateIGESFormat

			string MyDir = RunExamples.GetDataDir_IGESDrawings();

			string sourceFilePath = MyDir + ("figa2.igs");
			string outPath = MyDir + ("meshes.pdf");

			using (Image igesImage = Image.Load(sourceFilePath))

			{
				Aspose.CAD.ImageOptions.PdfOptions pdf = new Aspose.CAD.ImageOptions.PdfOptions();
				pdf.VectorRasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
				pdf.VectorRasterizationOptions.PageHeight = 1000;
				pdf.VectorRasterizationOptions.PageWidth = 1000;
				igesImage.Save("figa2.pdf", pdf);
			}
			//ExEnd:IntegrateIGESFormat
		}
	}
}