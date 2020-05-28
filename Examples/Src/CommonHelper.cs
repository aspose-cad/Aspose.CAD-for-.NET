using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp
{
    internal static class CommonHelper
    {
        internal const double DPI = 300;

        internal static int MMtoPixels(double mm, double dpi)
        {
            double inches = mm * 0.0393701;
            double pixels = dpi * inches;

            return (int)(pixels + 0.5);
        }

        internal static int INtoPixels(double inches, double dpi)
        {
            double pixels = dpi * inches;
            return (int)(pixels + 0.5);
        }
    }
}
