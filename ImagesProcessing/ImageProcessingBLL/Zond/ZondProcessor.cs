using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessingBLL.Zond
{
    public class ZondProcessor
    {
        public Zond ConvertImageToZond(Bitmap image)
        {
            return new Zond(ImageHelper.ConvertToPoints(image), image.Width, image.Height);
        }

        /// <summary>
        /// Draw few zonds on image
        /// </summary>
        /// <param name="image">image for drawing</param>
        /// <param name="zonds">list of zonds</param>
        /// <returns>count of zonds that cross image</returns>
        public int DrawZondsOnImage(Bitmap image, List<Zond> zonds)
        {
            var crossCount = 0;

            foreach (var zond in zonds)
            {
                if (zond.DrawOnImage(image))
                {
                    crossCount++;
                }
            }

            return crossCount;
        }
    }
}
