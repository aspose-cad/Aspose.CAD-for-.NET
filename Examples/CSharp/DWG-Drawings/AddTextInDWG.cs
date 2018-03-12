using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadObjects.AttEntities;
namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class AddTextInDWG
    {
        public static void Run() {

            //ExStart:AddTextInDWG
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string dwgPathToFile = MyDir + "sample.dwg";
            using (Image image = Image.Load(dwgPathToFile))
            {
                CadText cadText = new CadText();
                cadText.StyleType = "Standard";
                cadText.DefaultValue = "Some custom text";
                cadText.ColorId = 256;
                cadText.LayerName = "0";
                cadText.FirstAlignment.X = 47.90;
                cadText.FirstAlignment.Y = 5.56;
                cadText.TextHeight = 0.8;
                cadText.ScaleX = 0.0;
                CadImage cadImage = (CadImage)image;
                cadImage.BlockEntities["*Model_Space"].AddEntity(cadText);

                PdfOptions pdfOptions = new PdfOptions();
                CadRasterizationOptions cadRasterizationOptions = new CadRasterizationOptions();
                pdfOptions.VectorRasterizationOptions = cadRasterizationOptions;
                cadRasterizationOptions.DrawType = CadDrawTypeMode.UseObjectColor;
                cadRasterizationOptions.CenterDrawing = true;
                cadRasterizationOptions.PageHeight = 1600;
                cadRasterizationOptions.PageWidth = 1600;
                cadRasterizationOptions.Layouts = new string[] { "Model" };
                image.Save(GetFileFromDesktop(MyDir+"SimpleEntites_generated.dwg.pdf"), pdfOptions);
            }
        
           //ExEnd:AddTextInDWG
        }
    
    
    }
}
