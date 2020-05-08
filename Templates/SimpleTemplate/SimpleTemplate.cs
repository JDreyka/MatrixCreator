using System.Collections.Generic;
using System.Drawing;

namespace MatrixCreator.Templates
{
    public class SimpleTemplate : IMatrixTemplate
    {
        public string ImgTemplatePath => @"Templates\SimpleTemplate\SimpleTemplate.png";
        
        public Dictionary<MatrixType, (Point, Point)> BlockCoords => 
            new Dictionary<MatrixType, (Point, Point)>
            {
                [MatrixType.Urgent_Important] = (new Point(180, 180), new Point(1100, 590)),
                [MatrixType.NotUrget_Important] = (new Point(1120, 180), new Point(2040, 590)),
                [MatrixType.Urgent_NotImportant] = (new Point(180, 610), new Point(1100, 1020)),
                [MatrixType.NotUrget_NotImportant] = (new Point(1120, 610), new Point(2040, 1020)),
            };

        public MatrixDrawingData DrawingData { get; } = new MatrixDrawingData();
    }
}