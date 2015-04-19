using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ImageProcessingBLL.BinaryImages
{
    public class Block
    {
        private List<Point> block;

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
    }
}
