using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageProcessingBLL.BinaryImages.HandWriting
{
    public class HandWritingResolver
    {
        public Bitmap sourceImage;
        private List<Line> lines = new List<Line>();

        public HandWritingResolver(Bitmap image)
        {
            this.sourceImage = image;
            LinesDeviders();
        }

        private void LinesDeviders()
        {
            List<Point> prevContour = null;
            var points = ImageProcessingBLL.ImageHelper.GetStartPoints(sourceImage);
            var averageCount = points.Where(obj => obj.Value != 0).Average(obj => obj.Value);

            while (true)
            {
                Line line = new Line();
                var startPoint = ImageProcessingBLL.ImageHelper.GetStartPoint(sourceImage, points, averageCount);

                if (startPoint.X == 0 && startPoint.Y == 0)
                {
                    break;
                }

                do
                {
                    prevContour = ImageProcessingBLL.ImageHelper.СircuitZhukMethod(sourceImage,
                        prevContour == null ? 0 : prevContour.Max(obj => obj.X) + 1, startPoint);
                    if (prevContour != null)
                    {
                        line.AddBlock(new Block(prevContour));
                    }
                } while (prevContour != null);

                SetLineImage(line);
                line.ClearOn(sourceImage); ;
                lines.Add(line);
                points = ImageProcessingBLL.ImageHelper.GetStartPoints(sourceImage);
            }
        }


        private void SetLineImage(Line line)
        {
            var leftBorder = line.LeftBorder();
            var rightBorder = line.RightBorder();
            var rect = new Rectangle(leftBorder.X, leftBorder.Y, rightBorder.X - leftBorder.X,
                rightBorder.Y - leftBorder.Y);

            line.Image = sourceImage.Clone(rect, PixelFormat.Format24bppRgb);
        }

        public Line GetLine(int index)
        {
            return index < lines.Count ? lines[index] : null;    
        }
    }
}
