using Aspose.CAD.ImageOptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aspose.CAD.Examples.CSharp.Features
{
    class PutTimeoutOnSave
    {
        public static void Run() 
        {
            //ExStart:1
            string SourceDir = RunExamples.GetDataDir_DWGDrawings();
            string OutputDir = RunExamples.GetDataDir_Output();

            using (Image cadDrawing = Image.Load(SourceDir + "Drawing11.dwg"))
            {
                var rasterizationOptions = new CadRasterizationOptions();

                rasterizationOptions.PageWidth = cadDrawing.Size.Width;
                rasterizationOptions.PageHeight = cadDrawing.Size.Height;

                using (var its = new InterruptionTokenSource())
                {
                    PdfOptions CADf = new PdfOptions();
                    CADf.VectorRasterizationOptions = rasterizationOptions;
                    CADf.InterruptionToken = its.Token;

                    var exportTask = Task.Factory.StartNew(() =>
                    {
                        cadDrawing.Save(OutputDir + "PutTimeoutOnSave_out.pdf", CADf);
                    });

                    Thread.Sleep(10000);
                    its.Interrupt();

                    exportTask.Wait();
                }
            }
            //ExEnd:1
            Console.WriteLine("PutTimeoutOnSave executed successfully");
        }
    }
}
