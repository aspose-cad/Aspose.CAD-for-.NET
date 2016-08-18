Imports Aspose.CAD
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace ApplyLicense
    Public Class ApplyLicenseByPath
        Public Shared Sub Run()
            ' ExStart:ApplyLicenseByPath
            ' Set path of the license file, i.e. c:\temp\
            Dim dataDir As String = "c:\temp\"

            Dim license As New License()
            license.SetLicense(dataDir & Convert.ToString("Aspose.CAD.lic"))
            ' ExEnd:ApplyLicenseByPath
        End Sub
    End Class
End Namespace

