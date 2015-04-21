﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingBLL.BinaryImages.HandWriting
{
    public class Line
    {
        private List<Block> blocks = new List<Block>();

        public Line()
        {
        } 

        public Line(List<Block> blocks)
        {
            this.blocks = blocks;
        }

        public Bitmap Image
        {
            get;
            set;
        }

        public void AddBlock(Block block)
        {
            if (block != null)
            {
                blocks.Add(block);
            }
        }


        public Point LeftBorder()
        {
            int XMin = blocks.Min(obj => obj.Points.Min(coord => coord.X));
            int YMin = blocks.Min(obj => obj.Points.Min(coord => coord.Y));

            return new Point(XMin, YMin);
        }

        public Point RightBorder()
        {
            int XMax = blocks.Max(obj => obj.Points.Max(coord => coord.X));
            int YMax = blocks.Max(obj => obj.Points.Max(coord => coord.Y));

            return new Point(XMax, YMax);
        }

        public int BlocksCount
        {
            get
            {
                return blocks.Count;
            }
        }

        public double AverabeBlocksHeight
        {
            get
            {
                return blocks.Average(obj => obj.Height);
            }
        }

        public double AverabeBlocksWidth
        {
            get
            {
                return blocks.Average(obj => obj.Width);
            }
        }

        public int Height
        {
            get
            {
                return blocks.Max(obj => obj.Height);
            }
        }

        public void ClearOn(Bitmap image)
        {
            foreach (var block in blocks)
            {
                block.ClearOn(image);
            }
        }
    }
}
