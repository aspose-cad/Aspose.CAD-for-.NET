using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.ImageOptions;
namespace Aspose.CAD.Examples.CSharp.Export
{
    public class ExportToBMP
    {
        public static void Run()
        {
            //ExStart:ExportToBMP
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
           

           string fileName = GetFileFromDesktop("APFH Floor Plan.dwf");
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(fileName))
            {
                BmpOptions bmpOptions = new BmpOptions();
                var dwfRasterizationOptions = new DwfRasterizationOptions();
                bmpOptions.VectorRasterizationOptions = dwfRasterizationOptions;
                dwfRasterizationOptions.CenterDrawing = true;
                dwfRasterizationOptions.PageHeight = 500;
                dwfRasterizationOptions.PageWidth = 500;
                dwfRasterizationOptions.Layouts = new string[] { "Model" };
                // export
                string outPath = fileName + ".bmp";
                image.Save(outPath, bmpOptions);
            }
            
            
            //ExEnd:ExportToBMP           
            Console.WriteLine("\n3D images exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
