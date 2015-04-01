using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Point> СircuitZhukMethod(Bitmap image, int shift)
        {
//            for (int i = shift; i < image.Width; i++)
//            {
//                for (int j = 0; j < image.Height; j++)
//                {
//                    var pixel = image.GetPixel(i, j);
//
//                    if (pixel.GetBrightness() == 0.0)
//                    {
//                        return ZhukStart(image, new Point(i, j));
//                    }
//                }
//            }

            for (int i = shift; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    var pixel = image.GetPixel(i, j);

                    if (pixel.GetBrightness() == 0.0)
                    {
                        return ZhukStart(image, new Point(i, j));
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
