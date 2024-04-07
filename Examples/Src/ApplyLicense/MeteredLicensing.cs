using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.ApplyLicense
{
    class MeteredLicensing
    {

        public static void Run()
        {
            //ExStart:MeteredLicensing


            // Access the setMeteredKey property and pass public and private keys as parameters
            var instance = new Aspose.CAD.Metered();
            instance.SetMeteredKey("PublicKey", "PrivateKey");

            // Do processing
            //Aspose.CAD.FileFormats.Cad.CadImage image = (Aspose.CAD.FileFormats.Cad.CadImage)Aspose.CAD.Image.load("BlockRefDgn.dwg");
        }

    }
}
