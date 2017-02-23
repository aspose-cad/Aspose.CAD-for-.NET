Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD

Namespace ConvertingCAD

    Public Class AdjustingCADDrawingSize

        Public Shared Sub Run()
            ' ExStart:AdjustingCADDrawingSizeUsingUnitType

            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()

            Dim sourceFilePath As String = MyDir & Convert.ToString("sample.dwg")

            ' Load a CAD drawing in an instance of Image
            Using image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of BmpOptions class
                Dim bmpOptions As New Aspose.CAD.ImageOptions.BmpOptions()

                ' Create an instance of CadRasterizationOptions and set its various properties
                Dim cadRasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                bmpOptions.VectorRasterizationOptions = cadRasterizationOptions
                cadRasterizationOptions.CenterDrawing = True

                ' Set the UnitType property
                cadRasterizationOptions.UnitType = Aspose.CAD.ImageOptions.UnitType.Centimenter

                ' Set the layouts property
                cadRasterizationOptions.Layouts = New String() {"Model"}

                ' Export layout to BMP format
                Dim outPath As String = sourceFilePath + ".bmp"
                image.Save(outPath, bmpOptions)
            End Using


            ' ExEnd:AdjustingCADDrawingSizeUsingUnitType            

        End Sub

        Public Shared Sub AutoAdjustingCADDrawingSize()

            ' ExStart:AutoAdjustingCADDrawingSize

            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()

            Dim sourceFilePath As String = MyDir & Convert.ToString("sample.dwg")

            ' Load a CAD drawing in an instance of Image
            Using image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of BmpOptions class
                Dim bmpOptions As New Aspose.CAD.ImageOptions.BmpOptions()

                ' Create an instance of CadRasterizationOptions and set its various properties
                Dim cadRasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                bmpOptions.VectorRasterizationOptions = cadRasterizationOptions
                cadRasterizationOptions.CenterDrawing = True

                ' Set the layouts property
                cadRasterizationOptions.Layouts = New String() {"Model"}

                ' Export layout to BMP format
                Dim outPath As String = sourceFilePath + ".bmp"
                image.Save(outPath, bmpOptions)
            End Using

            ' ExEnd:AutoAdjustingCADDrawingSize

        End Sub

    End Class
End Namespace

