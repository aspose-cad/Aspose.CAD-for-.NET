
Namespace DWG_Drawings

    Public Class AccessingUnderlayFlagsofDWG

        Public Shared Sub Run()

            'ExStart: AccessingUnderlayFlagsofDWG

            ' Input file name and path
            Dim fileName As String = "BlockRefDgn.dwg"

            ' Load an existing DWG file and convert it into CadImage 
            Using image1 As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(Image.Load(fileName), Aspose.CAD.FileFormats.Cad.CadImage)

                ' Go through each entity inside the DWG file
                For Each entity As Aspose.CAD.FileFormats.Cad.CadObjects.CadBaseEntity In image1.Entities

                    ' Check if entity is of CadDgnUnderlay type
                    If TypeOf entity Is Aspose.CAD.FileFormats.Cad.CadObjects.CadDgnUnderlay Then

                        ' Access different underlay flags 
                        Dim underlay As Aspose.CAD.FileFormats.Cad.CadObjects.CadUnderlay = TryCast(entity, Aspose.CAD.FileFormats.Cad.CadObjects.CadUnderlay)
                        Console.WriteLine(underlay.UnderlayPath)
                        Console.WriteLine(underlay.UnderlayName)
                        Console.WriteLine(underlay.InsertionPoint.X)
                        Console.WriteLine(underlay.InsertionPoint.Y)
                        Console.WriteLine(underlay.RotationAngle)
                        Console.WriteLine(underlay.ScaleX)
                        Console.WriteLine(underlay.ScaleY)
                        Console.WriteLine(underlay.ScaleZ)
                        Console.WriteLine((underlay.Flags And Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.UnderlayIsOn) = Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.UnderlayIsOn)
                        Console.WriteLine((underlay.Flags And Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.ClippingIsOn) = Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.ClippingIsOn)
                        Console.WriteLine((underlay.Flags And Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.Monochrome) <> Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.Monochrome)
                        Exit For
                    End If
                Next
            End Using
            'ExEnd: AccessingUnderlayFlagsofDWG


        End Sub

    End Class

End Namespace
