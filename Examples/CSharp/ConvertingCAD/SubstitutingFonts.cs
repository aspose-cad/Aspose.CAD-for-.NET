using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace CSharp.ConvertingCAD
{
    public class SubstitutingFonts
    {
        public static void Run()
        {
            //ExStart:SubstitutingFonts
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            // Load a CAD drawing  in an instance of CadImage
            using (Aspose.CAD.FileFormats.Cad.CadImage cadImage = (Aspose.CAD.FileFormats.Cad.CadImage)Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Iterate over the items of CadStyleDictionary
                foreach (var style in cadImage.Styles.ValuesTyped)
                {
                    // Set the font name
                    style.PrimaryFontName = "Arial";
                }
            }            
            //ExEnd:SubstitutingFonts            
            Console.WriteLine("\nFont changed successfully.");
        }
        public static void SubstitutingFontByName()
        {
            //ExStart:SubstitutingFontByName
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            // Load a CAD drawing in an instance of CadImage
            using (Aspose.CAD.FileFormats.Cad.CadImage cadImage = (Aspose.CAD.FileFormats.Cad.CadImage)Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Specify the font for one particular style
                cadImage.Styles["Roman"].PrimaryFontName = "Arial";
            }
            //ExEnd:SubstitutingFontByName    
        }
    }
}
