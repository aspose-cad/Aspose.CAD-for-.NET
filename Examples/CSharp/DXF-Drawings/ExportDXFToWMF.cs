using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    public class ExportDXFToWMF
    {
        public static void Run()
        {
            //ExStart:ExportDXFToWMF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (var image = Image.Load("NRB-GRID-BLOCK-MD-PROVALVDK-241000-162000-45400.dgn"))
            {
                var vectorOptions = new CadRasterizationOptions();
                vectorOptions.AutomaticLayoutsScaling = true;
                vectorOptions.BackgroundColor = Color.Black;
                vectorOptions.PageWidth = 500;
                vectorOptions.PageHeight = 500;

                WmfOptions wmfOptions = new WmfOptions()
                {
                    VectorRasterizationOptions = vectorOptions
                };

                image.Save("NRB-GRID-BLOCK-MD-PROVALVDK-241000-162000-45400.dgn.wmf", vectorOptions);
            }
            //ExEnd:ExportDXFToWMF            
            Console.WriteLine("\nThe DXF drawing exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
