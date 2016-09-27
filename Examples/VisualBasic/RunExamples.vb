Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.IO
Imports Aspose.CAD.Examples.VisualBasic.ConvertingCAD
Imports Aspose.CAD.Examples.VisualBasic.DWG_Drawings
Imports Aspose.CAD.Examples.VisualBasic.DXF_Drawings
Imports Aspose.CAD.Examples.VisualBasic.Export
Imports Aspose.CAD.Examples.VisualBasic.Exporting_DGN

Module RunExamples
    Sub Main()
        Console.WriteLine("Open RunExamples.vb. " & vbLf & "In Main() method uncomment the example that you want to run.")
        Console.WriteLine("=====================================================")

        ' Uncomment the one you want to try out

        '' =====================================================
        '' =====================================================
        '' DWG-Drawings
        '' =====================================================
        '' =====================================================

        'ExportToPDF.Run()
        'ExportSpecificLayoutToPDF.Run()
        'GetBlockAttributeValue.Run()
        'SearchText.Run()

        '' =====================================================
        '' =====================================================
        '' DXF-Drawings
        '' =====================================================
        '' =====================================================

        'ExportDXFToPDF.Run()
        'ExportDXFSpecificLayerToPDF.Run()
        'ExportDXFSpecificLayoutToPDF.Run()


        '' =====================================================
        '' =====================================================
        '' ConvertingCAD
        '' =====================================================
        '' =====================================================

        'ConvertDrawingToRasterImage.Run()
        'ListLayouts.Run()
        'ConvertLayoutsToRasterImage.Run()
        'SettingCanvasSizeAndMode.Run()
        'SettingBackgroundAndDrawingColors.Run()
        'SettingAutoLayoutScaling.Run()
        'EnableTrackingForCADRendering.Run()
        'SubstitutingFonts.Run()
        'CADLayersToRasterImageFormats.Run()

        '' =====================================================
        '' =====================================================
        '' Export
        '' =====================================================
        '' =====================================================

        'Export3DImagestoPDF.Run()
        'CADLayoutsToPDF.Run()

        '' =====================================================
        '' =====================================================
        '' Exporting-DGN
        '' =====================================================
        '' =====================================================

        'ExportDGNToPdf.Run()
        'ExportDGNToRasterImage.Run()

        ' Stop before exiting
        Console.WriteLine(vbLf & vbLf & "Program Finished. Press any key to exit....")
        Console.ReadKey()
    End Sub
    Public Function GetDataDir_DWGDrawings() As [String]
        Return Path.GetFullPath(GetDataDir_Data() & Convert.ToString("DWG-Drawings/"))
    End Function
    Public Function GetDataDir_DXFDrawings() As [String]
        Return Path.GetFullPath(GetDataDir_Data() & Convert.ToString("DXF-Drawings/"))
    End Function
    Public Function GetDataDir_ConvertingCAD() As [String]
        Return Path.GetFullPath(GetDataDir_Data() & Convert.ToString("ConvertingCAD/"))
    End Function
    Public Function GetDataDir_ExportingDGN() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Exporting-DGN/")
    End Function

    Private Function GetDataDir_Data() As String
        Dim parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent
        Dim startDirectory As String = Nothing
        If parent IsNot Nothing Then
            Dim directoryInfo = parent.Parent
            If directoryInfo IsNot Nothing Then
                startDirectory = directoryInfo.FullName
            End If
        Else
            startDirectory = parent.FullName
        End If
        Return Path.Combine(startDirectory, "Data\")
    End Function
    Public Function GetOutputFilePath(inputFilePath As [String]) As String
        Dim extension As String = Path.GetExtension(inputFilePath)
        Dim filename As String = Path.GetFileNameWithoutExtension(inputFilePath)
        Return Convert.ToString(filename & Convert.ToString("_out_")) & extension
    End Function
End Module
