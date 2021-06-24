![Nuget](https://img.shields.io/nuget/v/Aspose.CAD) ![Nuget](https://img.shields.io/nuget/dt/Aspose.CAD) ![GitHub](https://img.shields.io/github/license/aspose-cad/Aspose.CAD-for-.NET)

# CAD File Conversion API for .NET

[Aspose.CAD for .NET](https://products.aspose.com/cad/net) is a standalone class library to enhance ASP.NET & Windows applications to process & render CAD drawings without requiring AutoCAD or any other rendering workflow. The CAD Class Library allows high quality [conversion of DWG, DWF, DWT and DXF](https://docs.aspose.com/cad/net/supported-file-formats/) files, layouts and layers to PDF & raster image formats.

<p align="center">

  <a title="Download complete Aspose.CAD for .NET source code" href="https://github.com/aspose-cad/Aspose.CAD-for-.NET/archive/master.zip">
	<img src="http://i.imgur.com/hwNhrGZ.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Demos](Demos)  | Source code for the live demos hosted at https://products.aspose.app/cad/family.
[Examples](Examples)  | A collection of .NET examples that help you learn and explore the API features.


## CAD File Processing Features

- Supports the latest versions of DWG, DWF, DWT & DXF formats.
- [Convert CAD to PDF](https://docs.aspose.com/cad/net/converting-cad-drawings-to-pdf-and-raster-image-formats/).
- Convert CAD drawings to raster image formats.
- Select and convert specific layouts & layers of CAD drawings.
- [Adjust CAD drawing size before rendering](https://docs.aspose.com/cad/net/adjusting-cad-drawing-size/).

## Read CAD Formats

**AutoCAD:** DWG, DWT, DWF, DWXF, IFC, PLT\
**MicroStation:** DGN\
**The Advanced Visualizer:** OBJ\
**Other:** STL, IGES, CFF2

## Save CAD As

**Fixed Layout:** PDF\
**Raster Images:** PNG, BMP, TIFF, JPEG, GIF

## Read & Write

**CAD:** DXF\
(Write features is partially supported.)

## Platform Independence

Aspose.CAD for .NET supports .NET framework (ASP.NET applications & Windows applications) as well as .NET Core. It supports any 32-bit or 64-bit operating system where .NET or Mono framework is installed, this includes but is not limited to, Microsoft Windows desktop (XP, Vista, 7, 8, 10), Microsoft Windows Server (2003, 2008, 2012), Microsoft Azure, Linux (Ubuntu, OpenSUSE, CentOS and others), and Mac OS X.

## Get Started with Aspose.CAD for .NET

Are you ready to give Aspose.CAD for .NET a try? Simply execute `Install-Package Aspose.CAD` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.CAD for .NET and want to upgrade the version, please execute `Update-Package Aspose.CAD` to get the latest version. 

## Export 3D AutoCAD Drawings to PDF using .NET

```csharp
using (var cadImage = Aspose.CAD.Image.Load("template.dxf"))
{
    var rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
    rasterizationOptions.PageWidth = 500;
    rasterizationOptions.PageHeight = 500;

    rasterizationOptions.Layouts = new string[] { "Model" };
    var pdfOptions = new PdfOptions();
    pdfOptions.VectorRasterizationOptions = rasterizationOptions;
    cadImage.Save("output.pdf", pdfOptions);
}
```

[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/cad/net) | [Docs](https://docs.aspose.com/cad/net/) | [Demos](https://products.aspose.app/cad/family) | [API Reference](https://apireference.aspose.com/cad/net) | [Examples](https://github.com/aspose-cad/Aspose.CAD-for-.NET) | [Blog](https://blog.aspose.com/category/cad/) | [Search](https://search.aspose.com/) | [Free Support](https://forum.aspose.com/c/cad) |  [Temporary License](https://purchase.aspose.com/temporary-license)
