/*using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Image = System.Drawing.Image;

namespace SecantMethod.TableServices
{
    public static class ServiceImage
    {
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static Bitmap ApplyFilters(Bitmap image)
        {
            Bitmap gsImage = Grayscale.CommonAlgorithms.BT709.Apply(image);
            var filter = new CannyEdgeDetector();
            Bitmap edge = filter.Apply(gsImage);
            var threshold = new Threshold();


            return threshold.Apply(edge);
        }

        public static List<Blob> GetBlobs(Bitmap bitmap)
        {
            var blobCounter = new BlobCounter();
            blobCounter.ProcessImage(bitmap);

            return blobCounter.GetObjectsInformation().ToList();
        }

        public static Bitmap GetMaxBitmapFromBlobs(Bitmap bitmap, List<Blob> blobs)
        {
            int max = blobs.Max(blob => blob.Area);

            var maxSegment = blobs.Where(blob => blob.Area == max).Select(blob => blob).First();

            Bitmap bmp = bitmap.Clone(new Rectangle(maxSegment.Rectangle.X,
                maxSegment.Rectangle.Y, maxSegment.Rectangle.Width,
                maxSegment.Rectangle.Height),
                PixelFormat.Format24bppRgb);

            return bmp;
        }


        public static Bitmap ResizeImage(Bitmap bitmap, int newX, int newY)
        {
            // Создать фильтр 
            ResizeBilinear filter = new ResizeBilinear(newX, newY);
            // применить фильтр 
            Bitmap newImage = filter.Apply(bitmap);
            return newImage;
        }


    }
}*/