using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace ImageProcessingBLL.Recognition
{
    public class RecognitionByIntensity: IRecognizable
    {
        public List<Object> GetLinearMetrics(Bitmap image)
        {
            return ImageHelper.GetLinearIntensivityList(image);
        }

        public double GetDistance(Bitmap first, Bitmap second)
        {
            return ImageHelper.EuclidDistance(first, second);
        }

        public int Recognition(List<DistanceByClass> distances)
        {
            var halfOfMaxDistance = Convert.ToInt32(distances.Max(obj => obj.Distance) / 2);

            var lst = distances.Where(obj => obj.Distance <= halfOfMaxDistance).GroupBy(obj => obj.ImageClass);

            var a = lst.Max(obj => obj.Count());
            return a;

        }
    }
}
