using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessingBLL
{
    public class HandWritingResolver
    {
        private Bitmap sourceImage;
        private List<Bitmap> lines; 

        public HandWritingResolver(Bitmap image)
        {
            this.sourceImage = image;
        }
    }
}