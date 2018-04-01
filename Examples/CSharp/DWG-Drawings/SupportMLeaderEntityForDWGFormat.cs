using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad.CadObjects;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    public class SupportMLeaderEntityForDWGFormat
     
    {
        public class Assert
        {
            public static bool AreEqual(Object left, Object right)
            {
                return left == right;
            }

            public static bool AreEqual(Object left, Object right, Object epsilon)
            {
                return left == right;
            }

            public static bool AreNotEqual(Object left, Object right)
            {
                return left == right;
            }
        }

        public static void Run()
        {
            //ExStart:SupportMLeaderEntityForDWGFormat
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string file = "file path";
            using (Image image = Image.Load(file))
            {
                // Test
                FileFormats.Cad.CadImage cadImage = (FileFormats.Cad.CadImage)image;

                Assert.AreNotEqual(cadImage.Entities.Length, 0);
                CadMLeader cadMLeader = (CadMLeader)cadImage.Entities[0];

                Assert.AreEqual(cadMLeader.StyleDescription, "Standard");
                Assert.AreEqual(cadMLeader.LeaderStyleId, "12E");
                Assert.AreEqual(cadMLeader.ArrowHeadId1, "639");
                Assert.AreEqual(cadMLeader.LeaderLineTypeID, "14");

                CadMLeaderContextData context = cadMLeader.ContextData;

                Assert.AreEqual(context.ArrowHeadSize, 30.0, 0.1);
                Assert.AreEqual(context.BasePoint.X, 481, 1);
                Assert.AreEqual(context.ContentScale, 1.0, 0.01);
                Assert.AreEqual(context.DefaultText.Value, "This is multileader with huge text\\P{\\H1.5x;6666666666666666666666666666\\P}bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
                Assert.AreEqual(context.HasMText, true);

                CadMLeaderNode mleaderNode = context.LeaderNode;

                Assert.AreEqual(mleaderNode.LastLeaderLinePoint.X, 473, 1);
                CadMLeaderLine leaderLine = mleaderNode.LeaderLine;

                Assert.AreEqual(leaderLine.BreakEndPoint, null);
                Assert.AreEqual(leaderLine.BreakPointIndex.Value, 0);
                Assert.AreEqual(leaderLine.BreakStartPoint, null);
                Assert.AreEqual(leaderLine.LeaderLineIndex.Value, 0);
                Assert.AreEqual(leaderLine.LeaderPoints.Count, 4);

                Assert.AreEqual(mleaderNode.BranchIndex, 0);
                Assert.AreEqual(mleaderNode.DogLegLength, 8.0, 0.1);

                Assert.AreEqual(context.HasMText, true);
                Assert.AreEqual(context.TextAttachmentType.Value, 1);
                Assert.AreEqual(context.TextBackgroundColor.Value, 18);
                Assert.AreEqual(context.TextHeight, 20.0, 0.1);
                Assert.AreEqual(context.TextStyleID.Value, "11");
                Assert.AreEqual(context.TextRotation.Value, 0.0, 0.01);

                Assert.AreEqual(cadMLeader.ArrowHeadId1, "639");
                Assert.AreEqual(cadMLeader.LeaderType, 1);
                Assert.AreEqual(cadMLeader.BlockContentColor, 0);
                Assert.AreEqual(cadMLeader.LeaderLineColor, 0);
                Assert.AreEqual(cadMLeader.TextHeight, 1.0, 0.01);
            }
            //ExEnd:SupportMLeaderEntityForDWGFormat 
        }
    }
}
