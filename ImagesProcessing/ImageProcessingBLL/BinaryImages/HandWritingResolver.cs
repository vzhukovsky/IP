using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ImageProcessingBLL
{
    public class HandWritingResolver
    {
        private Bitmap sourceImage;
        private int [][] sourceValueMatrix;
        private List<List<Point>> points = new List<List<Point>>();
        private List<Bitmap> lines; 

        public HandWritingResolver(Bitmap image)
        {
            this.sourceImage = image;
            sourceValueMatrix = BinaryImages.ImageHelper.GetValueMatrix(image);
            LinesDeviders();
        }

        private void LinesDeviders()
        {
            List<Point> prevContour = null;

            do
            {
                prevContour = ImageHelper.СircuitZhukMethod(sourceImage, prevContour == null ? 0 : prevContour.Max(obj => obj.X));
                points.Add(prevContour);
            } while (prevContour != null);

            Console.WriteLine(points.Count);

        }
    }
}