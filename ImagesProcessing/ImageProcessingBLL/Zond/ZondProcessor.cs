using System;
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
        public List<bool> DrawZondsOnImage(Bitmap image, List<Zond> zonds)
        {
            List<bool> crossList = new List<bool>();

            foreach (var zond in zonds)
            {
                crossList.Add(zond.DrawOnImage(image));
            }

            return crossList;
        }

        public Bitmap GetZondsImage(List<Zond> zonds)
        {
            Bitmap image = new Bitmap(50, 50);

            foreach (var zond in zonds)
            {
                zond.DrawOnImage(image);
            }

            return image;
        }
    }
}
