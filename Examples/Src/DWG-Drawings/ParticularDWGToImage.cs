using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class ParticularDWGToImage
    {
        public static void Run() 
        {
            //ExStart:ParticularDWGToImage
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string sourceFilePath = MyDir + "visualization_-_conference_room.dwg";
            var cadImage = (CadImage)Aspose.CAD.Image.Load(sourceFilePath);

            CadBaseEntity[] entities = cadImage.Entities;
            List<CadBaseEntity> filteredEntities = new List<CadBaseEntity>();

            foreach (CadBaseEntity baseEntity in entities)
            {
                // selection or filtration of entities
                if (baseEntity.TypeName == CadEntityTypeName.TEXT)
                {
                    filteredEntities.Add(baseEntity);
                }
                }

            cadImage.Entities = filteredEntities.ToArray();

            // Create an instance of CadRasterizationOptions and set its various properties
            Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions =
            new Aspose.CAD.ImageOptions.CadRasterizationOptions();
            rasterizationOptions.PageWidth = 1600;
            rasterizationOptions.PageHeight = 1600;

            // Set Auto Layout Scaling
            rasterizationOptions.AutomaticLayoutsScaling = true;

            // Create an instance of PdfOptions
            Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();

            // Set the VectorRasterizationOptions property
            pdfOptions.VectorRasterizationOptions = rasterizationOptions;

            string outFile = MyDir + "result_out_generated.pdf";

            // Export the CAD to PDF
            cadImage.Save(outFile, pdfOptions);

            //ExEnd:ParticularDWGToImage
    
        }

        private static string GetFileFromDesktop(string p)
        {
            throw new NotImplementedException();
        }
     }
}
