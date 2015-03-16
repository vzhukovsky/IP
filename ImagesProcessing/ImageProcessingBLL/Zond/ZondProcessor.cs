using System.Drawing;

namespace ImageProcessingBLL.Zond
{
    public class ZondProcessor
    {
        public Zond ConvertImageToZond(Bitmap image)
        {
            return new Zond(ImageHelper.ConvertToPoints(image));
        }
    }
}
