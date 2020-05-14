using System.Collections.Generic;
using System.Drawing;

namespace MatrixCreator.Templates
{
    public class PastelPicture : IMatrixTemplate
    {
        public string ImgTemplatePath => @"Templates\PastelPicture\PastelPicture.png";
        public Dictionary<MatrixType, (Point, Point)> BlockCoords => new Dictionary<MatrixType, (Point, Point)>()
        {
            [MatrixType.Urgent_Important] = (new Point(170,230), new Point(1580, 1000)),
            [MatrixType.NotUrget_Important] = (new Point(1700, 230), new Point(3170, 1000)),
            [MatrixType.Urgent_NotImportant] = (new Point(170,1130), new Point(1580, 1900)),
            [MatrixType.NotUrget_NotImportant] = (new Point(1700,1130), new Point(3170, 1900)),
        };
        public MatrixDrawingData DrawingData { get; } = new MatrixDrawingData()
        {
            FontName = "Consolas",
            FontSize = 14,
            LineSpacing = 12,
            TextColor = Color.FromArgb(79, 63, 40)
        };
    }
}