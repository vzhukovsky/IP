using System;
using System.Collections.Generic;
using System.Drawing;

namespace SecantMethod.TableServices
{
    public static class ServiceImagePriznaks
    {
        public static int GetCountWhitePixels(Bitmap imageBitmap)
        {
            var countWhitePixels = 0;

            for (int i = 0; i < imageBitmap.Width; i++)
            {
                for (int j = 0; j < imageBitmap.Height; j++)
                {
                    if (imageBitmap.GetPixel(i, j).GetBrightness() == 1)
                    {
                        countWhitePixels++;
                    }
                }
            }

            return countWhitePixels;
        }

        public static double GetHeightDivideWidth(Bitmap imageBitmap)
        {
            return (imageBitmap.Height + 0.0) / imageBitmap.Width;
        }

        public static List<double> GetCountWhitePixelsInArea(Bitmap bitmap)
        {
            var listCountWhitePixelsInArea = new List<double>();

            var centrWidth = bitmap.Width / 2;
            var centHeight = bitmap.Height / 2;

            listCountWhitePixelsInArea.Add(GetCountWhitePixelsInArea(bitmap, 0, 0, centrWidth, centHeight));
            listCountWhitePixelsInArea.Add(GetCountWhitePixelsInArea(bitmap, centrWidth, 0, bitmap.Width, centHeight));
            listCountWhitePixelsInArea.Add(GetCountWhitePixelsInArea(bitmap, 0, centHeight, centrWidth, bitmap.Height));
            listCountWhitePixelsInArea.Add(GetCountWhitePixelsInArea(bitmap, centrWidth, centHeight, bitmap.Width, bitmap.Height));

            return listCountWhitePixelsInArea;
        }

        private static int GetCountWhitePixelsInArea(Bitmap bitmap, int startX, int startY, int endX, int endY)
        {
            var countWhitePixels = 0;

            for (int x = startX; x < endX; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    if (bitmap.GetPixel(x, y).GetBrightness() == 1)
                    {
                        countWhitePixels++;
                    }
                }
            }

            return countWhitePixels;
        }
    }
}