Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD

Namespace DWG_Drawings
    Public Class ExportToPDF
        Public Shared Sub Run()
            ' ExStart:ExportToPDF
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_DWGDrawings()
            Dim sourceFilePath As String = MyDir & Convert.ToString("Bottom_plate.dwg")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of CadRasterizationOptions and set its various properties
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                rasterizationOptions.BackgroundColor = Aspose.CAD.Color.White
                rasterizationOptions.PageWidth = 1600
                rasterizationOptions.PageHeight = 1600

                ' Create an instance of PdfOptions
                Dim pdfOptions As New Aspose.CAD.ImageOptions.PdfOptions()
                ' Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions

                MyDir = MyDir & Convert.ToString("Bottom_plate_out.pdf")
                ' Export the DWG to PDF
                image.Save(MyDir, pdfOptions)
            End Using
            ' ExEnd:ExportToPDF            
            Console.WriteLine(Convert.ToString(vbLf & "The DWG file exported successfully to PDF." & vbLf & "File saved at ") & MyDir)
        End Sub
    End Class
End Namespace