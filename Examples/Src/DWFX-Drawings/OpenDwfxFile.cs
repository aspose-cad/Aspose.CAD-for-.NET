using Aspose.CAD.ImageOptions;
using System;

namespace Aspose.CAD.Examples.CSharp.DWFX_Drawings
{
    class OpenDwfxFile
    {
        public static void Run()
        {
            //ExStart:1
            string SourceDir = RunExamples.GetDataDir_DWFXDrawings();
            string OutputDir = RunExamples.GetDataDir_Output();

            using (Image cadDrawing = Image.Load(SourceDir + "Tyrannosaurus.dwfx"))
            {
                var rasterizationOptions = new CadRasterizationOptions();

                rasterizationOptions.PageWidth = cadDrawing.Size.Width;
                rasterizationOptions.PageHeight = cadDrawing.Size.Height;

                PdfOptions CADf = new PdfOptions();
                CADf.VectorRasterizationOptions = rasterizationOptions;

                cadDrawing.Save(OutputDir + "OpenDwfxFile_out.pdf", CADf);
            }
            //ExEnd:1
            Console.WriteLine("OpenDwfxFile executed successfully");
        }
    }
}
