using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace ImageProcessingBLL
{
    public abstract class ImageHelper
    {
        static private Bitmap GetImageSector(Bitmap image, Point startSector, Point endSector)
        {
            var newImageHeight = endSector.Y - startSector.Y;
            var newImageWidth = endSector.X - startSector.X;

            var newImage = new Bitmap(newImageWidth, newImageHeight);

            for (int i = 0; i < newImageWidth; i++)
            {
                for (int j = 0; j < newImageHeight; j++)
                {
                    newImage.SetPixel(i, j, image.GetPixel(startSector.X + i, startSector.Y + j));
                }
            }

            return newImage;
        }

        /// <summary>
        /// convert image to list of points
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        static public List<Point> ConvertToPoints(Bitmap image)
        {
            var points = new List<Point>();

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    var pixel = image.GetPixel(i, j); // getPixel - i less than Width

                    if (pixel.GetBrightness() == 0.0) 
                    {
                        points.Add(new Point()
                        {
                            X = i,
                            Y = j
                        });
                    }
                }
            }

            return points;
        }

        /// <summary>
        /// cut unnecessary parts of image
        /// </summary>
        /// <param name="image">required image with single painted object</param>
        /// <returns>new image</returns>
        static public Bitmap CutImage(Bitmap image)
        {
            var points = ConvertToPoints(image);
            var start = new Point()
            {
                X = points.Min(obj => obj.X),
                Y = points.Min(obj => obj.Y)
            };
            
            var end = new Point()
            {
                X = points.Max(obj => obj.X),
                Y = points.Max(obj => obj.Y)
            };

            return GetImageSector(image, start, end);
        }

        static public Bitmap ScaleImage(Bitmap image, int height = 0, int width = 0)
        {
            throw new NoNullAllowedException();
        }
    };
}
