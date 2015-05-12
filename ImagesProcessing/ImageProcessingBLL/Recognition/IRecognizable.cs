using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace ImageProcessingBLL.Recognition
{
    public interface IRecognizable
    {
        List<Object> GetLinearMetrics(Bitmap image);

        double GetDistance(Bitmap first, Bitmap second);

        int Recognition(List<DistanceByClass> distances);
    }
}
