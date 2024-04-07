using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad.CadTables;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadObjects;

namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
    public class ReadingDWT
    {
        public static void Run()
        {
            //ExStart:ReadingDWT
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            using (CadImage image = (CadImage)Image.Load(MyDir+"example.dwt"))
          {
           foreach (CadEntityBase entity in image.Entities)
         {
         //do your work here
          }
          }
            }
            //ExEnd:ReadingDWT
        }
    }

