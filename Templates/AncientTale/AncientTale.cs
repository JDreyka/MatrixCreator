using System.Collections.Generic;
using System.Drawing;

namespace MatrixCreator.Templates
{
    public class AncientTale : IMatrixTemplate
    {
        public string ImgTemplatePath => @"Templates\AncientTale\AncientTale.png";
        public Dictionary<MatrixType, (Point, Point)> BlockCoords => new Dictionary<MatrixType, (Point, Point)>()
        {
            [MatrixType.Urgent_Important] = (new Point(380,350), new Point(1500, 1110)),
            [MatrixType.NotUrget_Important] = (new Point(1630, 350), new Point(2750, 1110)),
            [MatrixType.Urgent_NotImportant] = (new Point(380,1240), new Point(1500, 1990)),
            [MatrixType.NotUrget_NotImportant] = (new Point(1630,1240), new Point(2750, 1990)),
        };
        public MatrixDrawingData DrawingData { get; } = new MatrixDrawingData()
        {
            FontName = "Consolas",
            FontSize = 12,
            LineSpacing = 12,
            TextColor = Color.FromArgb(255, 240, 240)
        };
    }
}