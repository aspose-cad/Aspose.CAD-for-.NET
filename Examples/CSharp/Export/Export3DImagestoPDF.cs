using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.ImageOptions;
namespace Aspose.CAD.Examples.CSharp.Export
{
    public class Export3DImagestoPDF
    {
        public static void Run()
        {
            //ExStart:Export3DImagestoPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (Aspose.CAD.Image cadImage = Aspose.CAD.Image.Load(sourceFilePath))
            {
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                rasterizationOptions.PageWidth = 500;
                rasterizationOptions.PageHeight = 500;
                rasterizationOptions.TypeOfEntities = TypeOfEntities.Entities3D;

                rasterizationOptions.Layouts = new string[] { "Model" };
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;
                MyDir = MyDir + "Export3DImagestoPDF_out.pdf";
                cadImage.Save(MyDir, pdfOptions);
            }
            //ExEnd:Export3DImagestoPDF            
            Console.WriteLine("\n3D images exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
