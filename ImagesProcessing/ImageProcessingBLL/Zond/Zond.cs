using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessingBLL.Zond
{
    public class Zond
    {
        protected List<Point> zond = new List<Point>();

        public Zond(List<Point> points)
        {
            zond = points;
        }

        public List<Point> GetZond()
        {
            return zond;
        }

        public void Draw(Bitmap image)
        {
            throw new NotImplementedException();
        }
    }
}
