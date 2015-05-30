using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using ImageProcessingBLL.Interfaces;
using SecantMethod.TablePriznakov;

namespace ImageProcessingBLL.BinaryImages.HandWriting
{
    public class HandWritingResolver: IRow
    {
        private Bitmap originalImage;
        private Bitmap image;
        private List<Line> lines = new List<Line>();

        public HandWritingResolver(Bitmap image)
        {

            this.image = new Bitmap(image);
            this.originalImage = new Bitmap(image);
            LinesDeviders();
        }

        private void LinesDeviders()
        {
            List<Point> prevContour = null;
            var points = ImageProcessingBLL.ImageHelper.GetStartPoints(image);
            var averageCount = points.Where(obj => obj.Value != 0).Average(obj => obj.Value);

            while (true)
            {
                Line line = new Line();
                var startPoint = ImageProcessingBLL.ImageHelper.GetStartPoint(image, points, averageCount);

                if (startPoint.X == 0 && startPoint.Y == 0)
                {
                    break;
                }

                do
                {
                    prevContour = ImageProcessingBLL.ImageHelper.СircuitZhukMethod(image,
                        prevContour == null ? 0 : prevContour.Max(obj => obj.X) + 1, startPoint);
                    if (prevContour != null)
                    {
                        line.AddBlock(new Block(prevContour));
                    }
                } while (prevContour != null);

                SetLineImage(line);
                line.ClearOn(image); ;
                lines.Add(line);
                points = ImageProcessingBLL.ImageHelper.GetStartPoints(image);
            }
        }

        private void SetLineImage(Line line)
        {
            var leftBorder = line.LeftBorder();
            var rightBorder = line.RightBorder();
            var rect = new Rectangle(leftBorder.X, leftBorder.Y, rightBorder.X - leftBorder.X,
                rightBorder.Y - leftBorder.Y);

            line.Image = image.Clone(rect, PixelFormat.Format24bppRgb);
        }

        public int LinesCount
        {
            get
            {
                return lines.Count;
            }
        }
        public Line GetLine(int index)
        {
            return index < lines.Count ? lines[index] : null;    
        }

        public Bitmap SourceImage
        {
            get
            {
                return originalImage;
            }
        }

        private double SampleMeanSquare(List<int> items, double average)
        {
            return Math.Sqrt(items.Sum(obj => Math.Pow(obj - average, 2)) / items.Count);
        }

        private double SampleMeanSquare(List<double> items, double average)
        {
            return Math.Sqrt(items.Sum(obj => Math.Pow(obj - average, 2)) / items.Count);
        }

        #region Signs

        //2
        public double SampleMeanFillingFactor()
        {
            return lines.Average(obj => obj.FillingFactor());
        }

        //3
        public double SampleMeanSquareFillingFactor()
        {
            var average = SampleMeanFillingFactor();
            var values = lines.Select(obj => obj.FillingFactor()).ToList();

            return SampleMeanSquare(values, average);
        }

        //4
        public double SampleMeanLineHeight()
        {
            return lines.Average(obj => obj.Height);
        }

        //5
        public double SampleMeanSquareLineHeight()
        {
            var average = lines.Average(obj => obj.Height);
            var values = lines.Select(obj => obj.Height).ToList();

            return SampleMeanSquare(values, average);
        }

        public List<double> GetLinesSpacing()
        {
            var linesSpacing = new List<double>();

            if (lines.Count > 1)
            {
                for (int i = 0; i < lines.Count - 1; i++)
                {
                    var bottom = lines[i].BottomMargin();
                    var top = lines[i + 1].TopMargin();

                    linesSpacing.Add(bottom + top);
                }
            }
            else
            {
                linesSpacing.Add(0);
            }

            return linesSpacing;
        } 

        //6
        public double SampleMeanLineSpacing()
        {
            return GetLinesSpacing().Average();
        }

        //7
        public double SampleMeanSquareLineSpacing()
        {
            var linesSpacing = GetLinesSpacing();
            var linesSpacingAverage = linesSpacing.Average();

            return SampleMeanSquare(linesSpacing, linesSpacingAverage);
        }

        //8
        public double SampleMeanBlocksWidth()
        {
            return lines.Average(obj => obj.AverabeBlocksWidth);
        }

        //9
        public double SampleMeanSquareBlocksWidth()
        {
            var average = lines.Average(obj => obj.AverabeBlocksWidth);
            var values = lines.Select(obj => obj.AverabeBlocksWidth).ToList();

            return SampleMeanSquare(values, average);
        }

        //16
        public double SampleMeanCountBlocks()
        {
            return lines.Average(obj => obj.BlocksCount);
        }

        //17
        public double SampleMeanSquareCountBlocks()
        {
            var average = lines.Average(obj => obj.BlocksCount);
            var values = lines.Select(obj => obj.BlocksCount).ToList();

            return SampleMeanSquare(values, average);
        }

        // 48
        public double SampleMeanLineItemSize()
        {
            return lines.Average(obj => obj.GetLineItemAverageSize());
        }

        // 49
        public double SampleMeanSquareLineItemSize()
        {
            var average = SampleMeanLineItemSize();
            var values = lines.Select(obj => obj.GetLineItemAverageSize()).ToList();
            return SampleMeanSquare(values, average);
        }

        
        #endregion

        public List<object> GetRow()
        {
            var items = new List<object>();

            items.Add(SampleMeanFillingFactor());
            items.Add(SampleMeanSquareFillingFactor());
            items.Add(SampleMeanLineHeight());
            items.Add(SampleMeanSquareLineHeight());
            items.Add(SampleMeanLineSpacing());
            items.Add(SampleMeanSquareLineSpacing());
            items.Add(SampleMeanBlocksWidth());
            items.Add(SampleMeanSquareBlocksWidth());
            items.Add(SampleMeanCountBlocks());
            items.Add(SampleMeanSquareCountBlocks());
            items.Add(SampleMeanLineItemSize());
            items.Add(SampleMeanSquareLineItemSize());

            return items;
        }

        public PriznakTable GetMetrics()
        {
            PriznakTable metrics = new PriznakTable();
            metrics.Priznaki = new Dictionary<string, double>();
            metrics.Priznaki.Add("1", SampleMeanFillingFactor());
            metrics.Priznaki.Add("2", SampleMeanSquareFillingFactor());
            metrics.Priznaki.Add("3", SampleMeanLineHeight());
            metrics.Priznaki.Add("4", SampleMeanSquareLineHeight());
            metrics.Priznaki.Add("5", SampleMeanLineSpacing());
            metrics.Priznaki.Add("6", SampleMeanSquareLineSpacing());
            metrics.Priznaki.Add("7", SampleMeanBlocksWidth());
            metrics.Priznaki.Add("8", SampleMeanSquareBlocksWidth());
            metrics.Priznaki.Add("9", SampleMeanCountBlocks());
            metrics.Priznaki.Add("10", SampleMeanSquareCountBlocks());
            metrics.Priznaki.Add("11", SampleMeanLineItemSize());
            metrics.Priznaki.Add("12", SampleMeanSquareLineItemSize());
            return metrics;
        }
    }
}
