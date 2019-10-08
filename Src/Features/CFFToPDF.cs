using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.Features
{
    class CFFToPDF
    {

        public static void Run() {

            //ExStart:CFFToPDF

            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCFF();

            using (Image image = Image.Load(MyDir + "WineBottle_Die.cf2"))
            {
                var options = new PdfOptions();
                image.Save(MyDir + "WineBottle_Die_out.pdf",options);
            }

            //ExEnd:CFFToPDF


        }
    }
}
