using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ImageProcessingBLL.BinaryImages
{
    public class Block
    {
        private List<Point> block;

        public Bitmap Image
        {
            get;
            set;
        }

        public Block(List<Point> block)
        {
            this.block = block;
        }

        public List<Point> Points
        {
            get
            {
                return block;
            }
        }

        public void ClearOn(Bitmap image)
        {
            var XRange = block.GroupBy(obj => obj.X).Select(obj => obj.First()).Select(obj => obj.X).ToList();

            foreach (var x in XRange)
            {
                var YRangeMin = block.Where(obj => obj.X == x).Min(obj => obj.Y);
                var YRangeMax = block.Where(obj => obj.X == x).Max(obj => obj.Y);

                for (int i = YRangeMin; i <= YRangeMax; i++)
                {
                    image.SetPixel(x, i, Color.White);
                }
            }
        }

        public int Width
        {
            get
            {
                return block.Max(obj => obj.X) - block.Min(obj => obj.X);
            }
        }

        public int Height
        {
            get
            {
                return block.Max(obj => obj.Y) - block.Min(obj => obj.Y);
            }
        }

        public Point LeftBorder()
        {
            int XMin = block.Min(coord => coord.X);
            int YMin = block.Min(coord => coord.Y);

            return new Point(XMin, YMin);
        }

        public Point RightBorder()
        {
            int XMax = block.Max(coord => coord.X);
            int YMax = block.Max(coord => coord.Y);

            return new Point(XMax, YMax);
        }
    }
}
