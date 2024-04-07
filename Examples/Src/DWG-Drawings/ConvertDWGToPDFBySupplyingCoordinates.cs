using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadParameters;
using Aspose.CAD.FileFormats.Cad.CadTables;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    public class ConvertDWGToPDFBySupplyingCoordinates
    {
        public static void Run()
        {
            //ExStart:1
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string sourceFilePath = MyDir + "visualization_-_conference_room.dwg";
            using (CadImage cadImage = (CadImage)Image.Load(sourceFilePath))
            {
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.Layouts = new string[] { "Model" };
                rasterizationOptions.NoScaling = true;

                // note: preserving some empty borders around part of image is the responsibility of customer
                // top left point of region to draw
                Point topLeft = new Point(500, 1000);
                double width = 3108;
                double height = 2489;

                CadVportTableObject newView = new CadVportTableObject();
                newView.Name = "*Active";
                newView.CenterPoint.X = topLeft.X + width / 2f;
                newView.CenterPoint.Y = topLeft.Y - height / 2f;
                newView.ViewHeight = height;
                newView.ViewAspectRatio = width / height;

                for (int i = 0; i < cadImage.ViewPorts.Count; i++)
                {
                    CadVportTableObject currentView = (CadVportTableObject)(cadImage.ViewPorts[i]);
                    if (cadImage.ViewPorts.Count == 1 || string.Equals(currentView.Name.ToLowerInvariant(), "*active"))
                    {
                        cadImage.ViewPorts[i] = newView;
                        break;
                    }
                }

                // Create an instance of PdfOptions
                Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();
                // Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                MyDir = MyDir + "ConvertDWGToPDFBySupplyingCoordinates_out.pdf";
                //Export the DWG to PDF
                cadImage.Save(MyDir, pdfOptions);                
            }
            //ExEnd:1            
            Console.WriteLine("\nThe DWG file exported successfully to PDF.\nFile saved at " + MyDir);

        }
    }
}
