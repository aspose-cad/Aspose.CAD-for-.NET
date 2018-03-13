using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad;

namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    class SaveDXFFiles
    {
        public static void Run()
        {
            //ExStart:SaveDXFFiles
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (CadImage cadImage = (CadImage)Image.Load(sourceFilePath))
            {
                // any entities updates
                cadImage.Save(MyDir+"conic.dxf");
            }

            //ExEnd:SaveDXFFiles
        }
    }
}