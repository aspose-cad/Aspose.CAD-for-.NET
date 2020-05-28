using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class DistinguishDWTAndDWGFormats
    {
        public static void Run() {
            //ExStart:DistinguishDWTAndDWGFormats
            var formatTypeDwt = Image.GetFileFormat(GetFileFromDesktop("sample.dwt"));
            Assert.IsTrue(formatTypeDwt.ToString().ToLower().Contains("dwt"));
            var formatTypeDwg = Image.GetFileFormat(GetFileFromDesktop("sample.dwg"));
            Assert.IsTrue(formatTypeDwg.ToString().ToLower().Contains("dwg"));

            //ExEnd:DistinguishDWTAndDWGFormats
        }
    }
}
