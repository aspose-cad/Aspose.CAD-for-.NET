Imports Aspose.CAD
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text

Namespace ApplyLicense
    Public Class ApplyLicenseUsingFileStream
        Public Shared Sub Run()
            ' ExStart:ApplyLicenseUsingFileStream
            ' Set path of the license file, i.e. c:\temp\
            Dim dataDir As String = "c:\temp\"
            ' Load an existing file in the stream
            Dim LicStream As New FileStream(dataDir & Convert.ToString("Aspose.CAD.lic"), FileMode.Open)

            Dim license As New License()
            license.SetLicense(LicStream)
            ' ExEnd:ApplyLicenseUsingFileStream
        End Sub

    End Class
End Namespace
