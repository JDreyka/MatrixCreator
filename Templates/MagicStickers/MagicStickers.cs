using System.Collections.Generic;
using System.Drawing;

namespace MatrixCreator.Templates
{
    public class MagicStickers : IMatrixTemplate
    {
        public string ImgTemplatePath => @"Templates\MagicStickers\MagicStickers.png";
        public Dictionary<MatrixType, (Point, Point)> BlockCoords => new Dictionary<MatrixType, (Point, Point)>()
        {
            [MatrixType.Urgent_Important] = (new Point(130,290), new Point(1280, 840)),
            [MatrixType.NotUrget_Important] = (new Point(1715, 290), new Point(2860, 840)),
            [MatrixType.Urgent_NotImportant] = (new Point(130,1290), new Point(1280, 1840)),
            [MatrixType.NotUrget_NotImportant] = (new Point(1715,1290), new Point(2860, 1840)),
        };
        public MatrixDrawingData DrawingData { get; } = new MatrixDrawingData()
        {
            FontName = "Consolas",
            FontSize = 9,
            LineSpacing = 12,
            TextColor = Color.FromArgb(21, 23, 31)
        };
    }
}