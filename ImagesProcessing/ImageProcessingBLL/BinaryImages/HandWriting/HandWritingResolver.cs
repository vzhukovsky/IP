using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageProcessingBLL.BinaryImages.HandWriting
{
    public class HandWritingResolver
    {
        private Bitmap originalImage;
        private Bitmap image;
        private List<Line> lines = new List<Line>();

        public HandWritingResolver(Bitmap image)
        {

            this.image = new Bitmap(image);
            this.originalImage = new Bitmap(image);
            LinesDeviders();
        }

        private void LinesDeviders()
        {
            List<Point> prevContour = null;
            var points = ImageProcessingBLL.ImageHelper.GetStartPoints(image);
            var averageCount = points.Where(obj => obj.Value != 0).Average(obj => obj.Value);

            while (true)
            {
                Line line = new Line();
                var startPoint = ImageProcessingBLL.ImageHelper.GetStartPoint(image, points, averageCount);

                if (startPoint.X == 0 && startPoint.Y == 0)
                {
                    break;
                }

                do
                {
                    prevContour = ImageProcessingBLL.ImageHelper.СircuitZhukMethod(image,
                        prevContour == null ? 0 : prevContour.Max(obj => obj.X) + 1, startPoint);
                    if (prevContour != null)
                    {
                        line.AddBlock(new Block(prevContour));
                    }
                } while (prevContour != null);

                SetLineImage(line);
                line.ClearOn(image); ;
                lines.Add(line);
                points = ImageProcessingBLL.ImageHelper.GetStartPoints(image);
            }
        }


        private void SetLineImage(Line line)
        {
            var leftBorder = line.LeftBorder();
            var rightBorder = line.RightBorder();
            var rect = new Rectangle(leftBorder.X, leftBorder.Y, rightBorder.X - leftBorder.X,
                rightBorder.Y - leftBorder.Y);

            line.Image = image.Clone(rect, PixelFormat.Format24bppRgb);
        }

        public int LinesCount
        {
            get
            {
                return lines.Count;
            }
        }
        public Line GetLine(int index)
        {
            return index < lines.Count ? lines[index] : null;    
        }

        public Bitmap SourceImage
        {
            get
            {
                return originalImage;
            }
        }
    }
}
