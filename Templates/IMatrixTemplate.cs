using System.Collections.Generic;
using System.Drawing;

namespace MatrixCreator.Templates
{
    public interface IMatrixTemplate
    {
        string ImgTemplatePath { get; }
        Dictionary<MatrixType, (Point, Point)> BlockCoords { get; }
        MatrixDrawingData DrawingData { get; }
    }
}