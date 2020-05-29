using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using MatrixCreator.Templates;

namespace MatrixCreator.Painter
{
    public static class MatrixPainter
    {
        public static string TemplatesPath { get; set; } =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void Draw(EisenhowerMatrix matrix, string matrixName, string savePath = null)
        {
            var matrixData = matrix.Data;
            var matrixTemplate = matrix.MatrixTemplate;
            var drawingData = matrixTemplate.DrawingData;
            
            var imgTemplatePath = Path.Combine(TemplatesPath, matrixTemplate.ImgTemplatePath);
            
            using var image = Image.FromFile(imgTemplatePath);
            using var graphics = Graphics.FromImage(image);

            foreach (var type in matrixData.Keys)
            {
                DrawMatrixBlock(graphics, matrixData[type], matrix.MatrixTemplate.BlockCoords[type], drawingData);
            }
            
            SaveImage(image, matrixName, savePath);
        }

        private static void SaveImage(Image image, string imageName, string savePath)
        {
            var path = savePath ?? Directory.GetCurrentDirectory();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            path = Path.Combine(path, imageName);
            image.Save(path + ".png", ImageFormat.Png);
        }

        private static void DrawMatrixBlock(
            Graphics graphics, 
            IEnumerable<MatrixItem> data, 
            (Point, Point) coords, 
            MatrixDrawingData drawingData)
        {
            using var font = GetFont(drawingData);
            using var brush = GetBrush(drawingData);
            
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