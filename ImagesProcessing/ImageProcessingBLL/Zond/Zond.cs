using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessingBLL.Zond
{
    public class Zond
    {
        private List<Point> points = new List<Point>();
        private int initialPictureWidth;
        private int initialPictureHeight;

        public Zond(List<Point> points, int initialPictureWidth, int initialPictureHeight)
        {
            this.points = points;
            this.initialPictureHeight = initialPictureHeight;
            this.initialPictureWidth = initialPictureWidth;
        }

        public List<Point> GetZond()
        {
            return points;
        }

        /// <summary>
        /// draw zond on image
        /// </summary>
        /// <param name="image">image for drawing</param>
        /// <returns>true - zond cross image. false - else</returns>
        public bool DrawOnImage(Bitmap image)
        {
            if (image != null && initialPictureWidth < image.Width && initialPictureHeight < image.Height)
            {
                var crossedImage = false;

                for (int i = 0; i < points.Count; i++)
                {
                    if (image.GetPixel(points[i].X, points[i].Y).GetBrightness() == 0.0)
                    {
                        crossedImage = true;
                    }

                    image.SetPixel(points[i].X, points[i].Y, Color.Black);
                }

                return crossedImage;
            }
            throw new InvalidOperationException();
        }
    }
}
