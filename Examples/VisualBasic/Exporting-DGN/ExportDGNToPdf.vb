Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD

Namespace Exporting_DGN
    Public Class ExportDGNToPdf
        Public Shared Sub Run()
            Try
                'ExStart:ExportDGNToPdf
                ' The path to the documents directory.
                Dim MyDir As String = RunExamples.GetDataDir_ExportingDGN()
                Dim sourceFilePath As String = MyDir & Convert.ToString("Nikon_D90_Camera.dgn")
                ' Load an existing DGN file as CadImage.
                Using cadImage As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(Aspose.CAD.Image.Load(sourceFilePath), Aspose.CAD.FileFormats.Cad.CadImage)
                    ' Create an object of CadRasterizationOptions class and define/set different properties
                    Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                    rasterizationOptions.PageWidth = 600
                    rasterizationOptions.PageHeight = 300
                    rasterizationOptions.CenterDrawing = True
                    rasterizationOptions.ScaleMethod = Aspose.CAD.FileFormats.Cad.ScaleType.None
                    rasterizationOptions.AutomaticLayoutsScaling = True

                    ' Create an object of PdfOptions class as we are converting the image to PDF format and assign CadRasterizationOptions object to it.
                    Dim pdfOptions As New Aspose.CAD.ImageOptions.PdfOptions()
                    pdfOptions.VectorRasterizationOptions = rasterizationOptions

                    ' Call the save method of the CadImage class object.
                    cadImage.Save(MyDir & Convert.ToString("ExportDGNToPdf_out_.pdf"), pdfOptions)
                End Using
                'ExEnd:ExportDGNToPdf            
                Console.WriteLine(Convert.ToString(vbLf & "The DGN file exported successfully to PDF." & vbLf & "File saved at ") & MyDir)
            Catch ex As Exception
                Console.WriteLine("Please use valid input file." + ex.Message)
            End Try

        End Sub
    End Class
End Namespace
