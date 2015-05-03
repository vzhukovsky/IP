using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ImageProcessingBLL.Recognition
{
    public class RecognitionResolver
    {
        private readonly int classesCount;
        private readonly string directoryPath;
        private List<List<Bitmap>> imagesByClass;

        public RecognitionResolver(int classesCount, string directoryPath)
        {
            this.classesCount = classesCount;
            this.directoryPath = directoryPath;
            imagesByClass = new List<List<Bitmap>>();

            LoadImages();
        }

        private void LoadImages()
        {
            for (int i = 1; i <= classesCount; i++)
            {
                LoadClassOfImage(i);
            }
         }

        private void LoadClassOfImage(int classNumber)
        {
            var filePattern = String.Concat(classNumber.ToString(), "-?.bmp");
            var filePaths = Directory.GetFiles(directoryPath, filePattern);

            if (filePaths.Count() != 0)
            {
                var images = filePaths.Select(path => new Bitmap(path)).ToList();
                imagesByClass.Add(images);
            }
        }


        private void InitColumn(DataTable dataTable)
        {
            dataTable.Columns.Add(new DataColumn("Class", typeof(int)));
            for (int i = 1; i <= 400; i++)
            {
                var column = new DataColumn(i.ToString(), typeof(int));
                dataTable.Columns.Add(column);
            }
        }

        private void FillImagesClass(DataTable dataTable, int imagesClass, List<Bitmap> images)
        {
            foreach (var image in images)
            {
                List<Object> list = new List<object>();
                list.Add(imagesClass);
                list.AddRange(ImageHelper.GetLinearIntensivityList(image));
                dataTable.Rows.Add(list.ToArray());
            }            
        }

        public DataTable GetDataSource()
        {
            DataTable dt = new DataTable();
            InitColumn(dt);
            for (int i = 0; i < imagesByClass.Count; i++)
            {
                FillImagesClass(dt, i + 1, imagesByClass[i]);;
            }
            return dt;
        }
    }
}
