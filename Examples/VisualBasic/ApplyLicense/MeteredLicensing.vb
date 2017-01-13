Imports Aspose.CAD
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text

Namespace ApplyLicense

    Public Class MeteredLicensing

        Public Shared Sub Run()

            ' ExStart:ApplyLicenseByPath

            ' Create an instance of CAD Metered class
            Dim metered As New Aspose.CAD.Metered()

            ' Access the setMeteredKey property and pass public and private keys as parameters
            metered.SetMeteredKey("*****", "*****")

            ' Get metered data amount before calling API
            Dim amountbefore As Decimal = Aspose.CAD.Metered.GetConsumptionQuantity()

            ' Display information
            Console.WriteLine("Amount Consumed Before: " + amountbefore.ToString())


            ' Do processing
            'Aspose.CAD.FileFormats.Cad.CadImage image = (Aspose.CAD.FileFormats.Cad.CadImage)Aspose.CAD.Image.load("BlockRefDgn.dwg");


            ' Get metered data amount After calling API
            Dim amountafter As Decimal = Aspose.CAD.Metered.GetConsumptionQuantity()

            ' Display information
            Console.WriteLine("Amount Consumed After: " + amountafter.ToString())

            ' ExEnd:ApplyLicenseByPath
        End Sub

    End Class

End Namespace


