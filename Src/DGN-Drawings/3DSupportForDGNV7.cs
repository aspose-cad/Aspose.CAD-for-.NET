using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;

namespace Aspose.CAD.Examples.CSharp.Exporting_DGN
{
    public class SupportForDGNV7
    {
        public static void Run()
        {
            try
            {
                //ExStart:SupportForDGNV7
                // The path to the documents directory.
                string MyDir = RunExamples.GetDataDir_ExportingDGN();
                string sourceFilePath = MyDir + "Nikon_D90_Camera.dgn";
                // Load an existing DGN file as CadImage.
                using (DgnImage dgnImage = (DgnImage)Image.Load(file))
                {
                    var options = new PdfOptions
                    {
                        VectorRasterizationOptions = new CadRasterizationOptions
                        {
                            PageWidth = 1500,
                            PageHeight = 1500,
                            CenterDrawing = true,
                            AutomaticLayoutsScaling = true,
                            BackgroundColor = Color.Black,
                            Layouts = new string[] { "1", "2", "3", "9" }//only export 4 (1,2,3 and 9) views
                        }
                    };

                    dgnImage.Save(outFile, options);
                }
                //ExEnd:SupportForDGNV7  
                Console.WriteLine("\nThe DGN file exported successfully to raster image.\nFile saved at " + MyDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please use valid input file." + ex.Message);
            }

        }
    }
}
