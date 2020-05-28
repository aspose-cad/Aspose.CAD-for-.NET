using System;
using Aspose.CAD.FileFormats.Cad;
namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class OverrideAutomaticCodePageDetectionDwg
    {
        public static void Run()
        {
            //ExStart:1
            string SourceDir = RunExamples.GetDataDir_DWGDrawings();
            using (CadImage cadImage = (CadImage)Image.Load(SourceDir + "SimpleEntites.dwg",
            new LoadOptions()
            {
                SpecifiedEncoding = CodePages.Japanese,
                SpecifiedMifEncoding = MifCodePages.Japanese,
                RecoverMalformedCifMif = false
            }))
            {
                //do export or something else with cadImage
            }
            //ExEnd:1
            Console.WriteLine("OverrideAutomaticCodePageDetectionDwg executed successfully");
        }
    }
}
