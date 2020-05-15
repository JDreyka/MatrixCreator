using System;
using System.Collections.Generic;
using System.Drawing;
using MatrixCreator.Templates;

namespace MatrixCreator.Painter
{
    public static class MatrixPainter
    {
        public static void Draw(EisenhowerMatrix matrix, string matrixName)
        {
            var matrixData = matrix.Data;
            var matrixTemplate = matrix.MatrixTemplate;
            var drawingData = matrixTemplate.DrawingData;
            
            var image = Image.FromFile(matrixTemplate.ImgTemplatePath);
            var graphics = Graphics.FromImage(image);

            foreach (var type in matrixData.Keys)
            {
                DrawMatrixBlock(graphics, matrixData[type], matrix.MatrixTemplate.BlockCoords[type], drawingData);
            }
            
            image.Save(matrixName + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private static void DrawMatrixBlock(
            Graphics graphics, 
            IEnumerable<MatrixItem> data, 
            (Point, Point) coords, 
            MatrixDrawingData drawingData)
        {
            var font = GetFont(drawingData);
            var brush = GetBrush(drawingData);
            
            var currentPosition = coords.Item1;

            foreach (var matrixItem in data)
            {
                var size = graphics.MeasureString(matrixItem.Value, font, GetSize(coords));

                if (currentPosition.Y + size.Height + drawingData.LineSpacing <= coords.Item2.Y)
                    graphics.DrawString(matrixItem.Value, font, brush, new Rectangle(currentPosition, GetSize(coords)));
                else throw new PainterException($"Failed to put item:{matrixItem.Value} in block");

                currentPosition.Y += (int)size.Height + drawingData.LineSpacing;
            }
        }
        
        private static Font GetFont(MatrixDrawingData drawingData) 
            => new Font(new FontFamily(drawingData.FontName),drawingData.FontSize);

        private static Brush GetBrush(MatrixDrawingData drawingData) 
            => new SolidBrush(drawingData.TextColor);

        private static Size GetSize((Point, Point) coords)
        {
            var width = coords.Item2.X - coords.Item1.X;
            var height = coords.Item2.Y - coords.Item1.Y;
            
            return new Size(width, height);
        }
    }
}