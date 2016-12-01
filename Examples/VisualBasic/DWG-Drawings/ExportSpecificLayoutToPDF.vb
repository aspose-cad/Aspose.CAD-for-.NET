Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD

Namespace DWG_Drawings
    Public Class ExportSpecificLayoutToPDF
        Public Shared Sub Run()
            ' ExStart:ExportSpecificLayoutToPDF
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_DWGDrawings()
            Dim sourceFilePath As String = MyDir & Convert.ToString("visualization_-_conference_room.dwg")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of CadRasterizationOptions and set its various properties
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                rasterizationOptions.PageWidth = 1600
                rasterizationOptions.PageHeight = 1600
                ' Specify desired layout name
                rasterizationOptions.Layouts = New String() {"Layout1"}
                ' Create an instance of PdfOptions
                Dim pdfOptions As New Aspose.CAD.ImageOptions.PdfOptions()
                ' Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions

                MyDir = MyDir & Convert.ToString("ExportSpecificLayoutToPDF_out.pdf")
                ' Export the DWG to PDF
                image.Save(MyDir, pdfOptions)
            End Using
            ' ExEnd:ExportSpecificLayoutToPDF            
            Console.WriteLine(Convert.ToString(vbLf & "The DWG file with specific layout exported successfully to PDF." & vbLf & "File saved at ") & MyDir)
        End Sub
    End Class
End Namespace
