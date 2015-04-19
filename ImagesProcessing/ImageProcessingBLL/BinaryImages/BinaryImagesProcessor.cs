using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
