using Aspose.CAD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.ApplyLicense
{
    public class ApplyLicenseUsingFileStream
    {
        public static void Run()
        {
            // ExStart:ApplyLicenseUsingFileStream
            // Set path of the license file, i.e. c:\temp\
            string dataDir = @"c:\temp\";
            // Load an existing file in the stream
            FileStream LicStream = new FileStream(dataDir + "Aspose.CAD.lic", FileMode.Open);

            License license = new License();
            license.SetLicense(LicStream);
            // ExEnd:ApplyLicenseUsingFileStream
        }

    }
}
