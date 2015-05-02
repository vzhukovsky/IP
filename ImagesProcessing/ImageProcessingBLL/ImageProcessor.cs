﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using AForge.Imaging.Filters;

namespace ImageProcessingBLL
{
    public abstract partial class ImageHelper
    {
        static private Bitmap GetImageSector(Bitmap image, Point startSector, Point endSector)
        {
            var newImageHeight = endSector.Y - startSector.Y;
            var newImageWidth = endSector.X - startSector.X;

            var newImage = new Bitmap(newImageWidth + 2, newImageHeight + 2);

            for (int i = 0; i < newImageWidth + 2; i++)
            {
                for (int j = 0; j < newImageHeight + 2; j++)
                {
                    newImage.SetPixel(i, j, image.GetPixel(startSector.X + i - 1, startSector.Y + j - 1));
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
        static public Bitmap CutImage(Bitmap image, int indent = 5)
        {
            var points = ConvertToPoints(image);
            var XMin = points.Min(obj => obj.X);
            var YMin = points.Min(obj => obj.Y);
            var XMax = points.Max(obj => obj.X);
            var YMax = points.Max(obj => obj.Y);

            var start = new Point()
            {
                X = XMin > indent ? XMin - indent : XMin,
                Y = YMin > indent ? YMin - indent : YMin
            };
            
            var end = new Point()
            {
                X = XMax + indent < image.Width ? XMax + indent : XMax,
                Y = YMax + indent < image.Height ? YMax + indent : YMax
            };

            return GetImageSector(image, start, end);
        }

        static public Bitmap ScaleImage(Bitmap image, int width = 50, int height = 50)
        {
            var resizer = new ResizeNearestNeighbor(width, height);
            return resizer.Apply(image);
        }

        public static void DrawPoints(Bitmap image, List<Point> points, Color color)
        {
            for (int i = 0; i < points.Count; i++)
            {
                image.SetPixel(points[i].X, points[i].Y, color);
            }
        }

    };
}