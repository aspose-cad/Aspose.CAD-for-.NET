using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;


namespace Aspose.CAD.Examples.CSharp.Exporting_DGN
{
    class ExportDGNAsPartofDWG
    {

        public static void Run()
        {
            try
            {
                //ExStart:ExportDGNAsPartofDWG

                // Input and Output file paths
                string fileName = "BlockRefDgn.dwg";
                string outPath = fileName + ".pdf";

                // Create an instance of PdfOptions class as we are exporting the DWG file to PDF format
                Aspose.CAD.ImageOptions.PdfOptions exportOptions = new Aspose.CAD.ImageOptions.PdfOptions();

                // Load any existing DWG file as image and convert it to CadImage type
                using (Aspose.CAD.FileFormats.Cad.CadImage cadImage = (Aspose.CAD.FileFormats.Cad.CadImage)Image.Load(fileName))
                {
                    // Go through each entity inside the DWG file
                    foreach (Aspose.CAD.FileFormats.Cad.CadObjects.CadBaseEntity baseEntity in cadImage.Entities)
                    {
                        // Check if entity is an image definition
                        if (baseEntity.TypeName == Aspose.CAD.FileFormats.Cad.CadConsts.CadEntityTypeName.DGNUNDERLAY)
                        {
                            Aspose.CAD.FileFormats.Cad.CadObjects.CadDgnUnderlay dgnFile = (Aspose.CAD.FileFormats.Cad.CadObjects.CadDgnUnderlay)baseEntity;

                            // Get external reference to object
                            System.Console.WriteLine(dgnFile.UnderlayPath);
                        }
                    }

                    // Define settings for CadRasterizationOptions object
                    exportOptions.VectorRasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions()
                    {
                        PageWidth = 1600,
                        PageHeight = 1600,
                        CenterDrawing = true,
                        Layouts = new string[] { "Model" },
                        AutomaticLayoutsScaling = false,
                        NoScaling = true,
                        BackgroundColor = Color.Black,
                        DrawType = Aspose.CAD.FileFormats.Cad.CadDrawTypeMode.UseObjectColor
                    };

                    //Export the DWG to PDF by calling Save method
                    cadImage.Save(outPath, exportOptions);
                }
                //ExEnd:ExportDGNAsPartofDWG

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please use valid input file." + ex.Message);
            }

        }

    }
}
