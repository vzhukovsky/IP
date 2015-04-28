using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace ImageProcessingBLL.BinaryImages
{
    public class ImageHelper
    {
        public static bool IsBlackPixel(Color pixel)
        {
            return pixel.GetBrightness() == 0.0;
        }

        public static bool IsWhitePixel(Color pixel)
        {
            return pixel.GetBrightness() != 0.0;
        }

        public static int GetPixelValue(Color pixel)
        {
            return pixel.GetBrightness() == 0.0 ? 1 : 0;
        }

        public static int[][] GetValueMatrix(Bitmap image)
        {
            int[][] values = new int[image.Height][];
            for (int i = 0; i < image.Height; i++)
            {
                values[i] = new int[image.Width];
                for (int j = 0; j < image.Width; j++)
                {
                    values[i][j] = GetPixelValue(image.GetPixel(j, i));
                }
            }

            return values;
        }

        public static double GetAvarageBottomMargin(Bitmap image)
        {
            if (image == null)
            {
                throw new InvalidEnumArgumentException();
            }

            var margins = new List<int>();

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = image.Height - 1; j > 0 ; j--)
                {
                    var pixel = image.GetPixel(i, j);
                    if (pixel.GetBrightness() == 0.0)
                    {
                        margins.Add(image.Height - j);
                        break;
                    }
                }
            }

            return margins.Average();
        }


        public static double GetAvarageTopMargin(Bitmap image)
        {
            if (image == null)
            {
                throw new InvalidEnumArgumentException();
            }

            var margins = new List<int>();

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    var pixel = image.GetPixel(i, j);
                    if (pixel.GetBrightness() == 0.0)
                    {
                        margins.Add(j);
                        break;
                    }
                }
            }

            return margins.Average();
        }
    }
}
