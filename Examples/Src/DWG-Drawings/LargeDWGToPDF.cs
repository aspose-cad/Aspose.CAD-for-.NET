using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class LargeDWGToPDF
    {
        public static void Run() {

            //ExStart:LargeDWGToPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();

            string filePathDWG = MyDir + "TestBigFile.dwg";
            string filePathFinish = MyDir+ "TestBigFile.dwg.pdf";
            Stopwatch stopWatch = new Stopwatch();


            try
            {
                stopWatch.Start();
                using (CadImage cadImage = (CadImage)Image.Load(filePathDWG))
                {
                    stopWatch.Stop();


                    // Get the elapsed time as a TimeSpan value. 
                    TimeSpan ts = stopWatch.Elapsed;

                    // Format and display the TimeSpan value. 
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine("RunTime for loading " + elapsedTime);

                    CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                    rasterizationOptions.PageWidth = 1600;
                    rasterizationOptions.PageHeight = 1600;
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                    stopWatch = new Stopwatch();
                    stopWatch.Start();
                    cadImage.Save(filePathFinish, pdfOptions);
                    stopWatch.Stop();

                    // Get the elapsed time as a TimeSpan value. 
                    ts = stopWatch.Elapsed;

                    // Format and display the TimeSpan value. 
                    elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                       ts.Hours, ts.Minutes, ts.Seconds,
                       ts.Milliseconds / 10);
                    Console.WriteLine("RunTime for converting " + elapsedTime);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
			
			//ExEnd:LargeDWGToPDF
        }
    }
}
