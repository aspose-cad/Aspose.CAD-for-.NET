Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Namespace DXF_Drawings
    Public Class ExportDXFSpecificLayoutToPDF
        Public Shared Sub Run()
            ' ExStart:ExportDXFSpecificLayoutToPDF
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_DXFDrawings()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of CadRasterizationOptions and set its various properties
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                rasterizationOptions.PageWidth = 1600
                rasterizationOptions.PageHeight = 1600
                ' Specify desired layout name
                rasterizationOptions.Layouts = New String() {"Model"}

                ' Create an instance of PdfOptions
                Dim pdfOptions As New Aspose.CAD.ImageOptions.PdfOptions()
                ' Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions

                MyDir = MyDir & Convert.ToString("conic_pyramid_layout_out.pdf")
                ' Export the DXF to PDF
                image.Save(MyDir, pdfOptions)
            End Using
            ' ExEnd:ExportDXFSpecificLayoutToPDF            
            Console.WriteLine(Convert.ToString(vbLf & "The DXF file with specific layout exported successfully to PDF." & vbLf & "File saved at ") & MyDir)
        End Sub
    End Class
End Namespace