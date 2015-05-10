using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessingBLL.Recognition
{
    public class RecognitionByA8: IRecognizable
    {
        public List<Object> GetLinearMetrics(Bitmap image)
        {
            return ImageHelper.GetLinearA8List(image);
        }

        public double GetDistance(Bitmap first, Bitmap second)
        {
            return ImageHelper.EuclidDistance(first, second);
        }

        public int Recognition(List<DistanceByClass> distances)
        {
            throw new NotImplementedException();
        }
    }
}
