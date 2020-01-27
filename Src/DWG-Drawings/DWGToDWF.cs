using Aspose.CAD.FileFormats.Cad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class DWGToDWF
    {
        public static void Run()
        {
            //ExStart:DWGToDWF
            string MyDir = RunExamples.GetDataDir_DWGDrawings();

            string inputFile = MyDir + "Line.dwg";
            string outFile = MyDir + "Line_20.1.dwf";
            using (var cadImage = (CadImage)Image.Load(inputFile))
            {
                cadImage.Save(outFile);
            }


            //ExEnd:DWGToDWF
        }

    }
}
