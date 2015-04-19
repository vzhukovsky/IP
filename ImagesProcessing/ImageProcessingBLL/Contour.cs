using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ImageProcessingBLL
{
    public abstract partial class ImageHelper
    {
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        };

        enum Turn
        {
            Left, 
            Right
        }

        private static Direction TurnOn(ref Point point, Direction direction, Turn turn)
        {
            switch (direction)
            {
                case Direction.Left:
                {
                    if (turn == Turn.Left)
                    {
                        point.Y++;
                        return Direction.Down;
                    }
                    else
                    {
                        point.Y--;
                        return Direction.Up;
                    }
                }
                break;

                case Direction.Right:
                {
                    if (turn == Turn.Left)
                    {
                        point.Y--;
                        return Direction.Up;
                    }
                    else
                    {
                        point.Y++;
                        return Direction.Down;
                    }
                }
                break;

                case Direction.Up:
                {
                    if (turn == Turn.Left)
                    {
                        point.X--;
                        return Direction.Left;
                    }
                    else
                    {
                        point.X++;
                        return Direction.Right;
                    }
                }
                break;

                case Direction.Down:
                {
                    if (turn == Turn.Left)
                    {
                        point.X++;
                        return Direction.Right;
                    }
                    else
                    {
                        point.X--;
                        return Direction.Left;
                    }
                }
                break;
                    
            }

            return Direction.Left;
        }

        private static List<Point> ZhukStart(Bitmap image, Point startPoint)
        {
            var beginPoint = new Point(startPoint.X, startPoint.Y); // turn left
            var contour = new List<Point>();
            var direction = Direction.Right;
            while (true)
            {
                var pixel = image.GetPixel(beginPoint.X, beginPoint.Y);

                if (pixel.GetBrightness() == 0.0)
                {
                    contour.Add(new Point(beginPoint.X, beginPoint.Y));
                    direction = TurnOn(ref beginPoint, direction, Turn.Left);
                }
                else
                {
                    direction = TurnOn(ref beginPoint, direction, Turn.Right);
                }

                if (startPoint.X == beginPoint.X && startPoint.Y == beginPoint.Y)
                {
                    return contour;
                }
            }
            throw new NotImplementedException();
        }

        public static Dictionary<int, int> GetStartPoints(Bitmap image)
        {
            Dictionary<int, int> points = new Dictionary<int, int>();

            for (int i = 0; i < image.Height; i++)
            {
                var count = 0;
                for (int j = 0; j < image.Width; j++)
                {
                    var pixel = image.GetPixel(j, i);
                    if (BinaryImages.ImageHelper.IsBlackPixel(pixel))
                    {
                       count++;
                    }
                }

                points.Add(i, count);
            }
            return points;
        } 


        public static Point GetStartPoint(Bitmap image, Dictionary<int, int> points, double averageCount)
        {
            var pointsFiltred = points.Where(obj => obj.Value < averageCount).ToDictionary(obj => obj.Key, obj => obj.Value);
            var pointsFiltredKeys = pointsFiltred.Select(obj => obj.Key).ToList();

            for (int i = 0; i < pointsFiltredKeys.Count - 1; i++)
            {
                if (pointsFiltredKeys[i] != pointsFiltredKeys[i + 1] - 1)
                {
//                    var pointsRange = points.Where(obj => (obj.Key >= pointsFiltredKeys[i] && obj.Key <= pointsFiltredKeys[i + 1])).ToDictionary(obj => obj.Key, obj => obj.Value);
//                    var maxValue = pointsRange.Max(obj => obj.Value);
//                    var maxValueKey = pointsRange.Where(obj => obj.Value == maxValue).Select(obj => obj.Key).First();
                    return new Point(pointsFiltredKeys[i], pointsFiltredKeys[i + 1]);
                }
            }

            return new Point();
        }


        public static List<Point> СircuitZhukMethod(Bitmap image, int shiftWidth, Point startPoint)
        {
//            height = height == 0 ? image.Height : height;
//
//            if (shiftWidth == 0 && shiftHeight == 0)
//            {
//                var startPoint = GetStartPoint(image);
//                shiftWidth = startPoint.X;
//                shiftHeight = startPoint.Y;
//            }

//            for (int i = shiftWidth; i < shiftHeight + height; i++)
//            {
//                for (int j = shiftHeight; j < shiftHeight + height; j++)
//                {
//                    var pixel = image.GetPixel(i, j);
//
//                    if (pixel.GetBrightness() == 0.0)
//                    {
//                        return ZhukStart(image, new Point(i, j));
//                    }
//                }
//            }

            int startBlock = startPoint.X - 1;
            var endBlock = startPoint.Y;

            for (int i = shiftWidth; i < image.Width; i++)
            {
                for (int j = startBlock; j < endBlock; j++)
                {
                    var pixel = image.GetPixel(i, j);
                    
                    if (pixel.GetBrightness() == 0.0)
                    {
                        return ZhukStart(image, new Point(i, j));
                    }

                    image.SetPixel(i, j, Color.Red);
                }
            }
            

            return null;
        }
    }
}
