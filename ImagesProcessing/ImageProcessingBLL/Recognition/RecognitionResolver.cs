using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Security.Principal;

namespace ImageProcessingBLL.Recognition
{
    public class RecognitionResolver
    {
        private readonly int classesCount;
        private readonly string directoryPath;
        private List<Bitmap> imagesByClass = new List<Bitmap>();
        private DataTable dataTable;
        private IRecognizable recognitionEngine;

        public RecognitionResolver(int classesCount, string directoryPath, IRecognizable recognitionEngine)
        {
            this.classesCount = classesCount;
            this.directoryPath = directoryPath;
            this.recognitionEngine = recognitionEngine;

            LoadImages();
            InitDataTable();
        }


        private void InitDataTable()
        {
            dataTable = new DataTable();
            InitColumn(dataTable);
            for (int i = 0; i < imagesByClass.Count; i++)
            {
                AddImageAsRow(dataTable, imagesByClass[i]); ;
            }
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
                images.ForEach(obj => obj.Tag = classNumber);
                imagesByClass.AddRange(images);
            }
        }


        private void InitColumn(DataTable dataTable)
        {
            dataTable.Columns.Add(new DataColumn("Index", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Class", typeof(int)));
            for (int i = 1; i <= 400; i++)
            {
                var column = new DataColumn(i.ToString(), typeof(int));
                dataTable.Columns.Add(column);
            }
            dataTable.Columns.Add(new DataColumn("Euclid", typeof(int)));
        }

        private int ParseImageClass(Bitmap image)
        {
            return Convert.ToInt32(image.Tag);
        }

        private void AddImageAsRow(DataTable dataTable, Bitmap image)
        {
            List<Object> list = new List<object>();
            list.Add(dataTable.Rows.Count + 1);
            list.Add(ParseImageClass(image));
            list.AddRange(recognitionEngine.GetLinearMetrics(image));
            dataTable.Rows.Add(list.ToArray());
        }

        public DataTable GetDataSource()
        {
            return dataTable;
        }



        public int Recognition(Bitmap imageForRecognition)
        {
            List<DistanceByClass> distances = new List<DistanceByClass>();
            var imageForRecognitionIntensivity = recognitionEngine.GetLinearMetrics(imageForRecognition);

            for (int i = 0; i < imagesByClass.Count; i++)
            {
                var distance = recognitionEngine.GetDistance(imagesByClass[i], imageForRecognition);
                distances.Add(new DistanceByClass()
                {
                    Distance = distance,
                    ImageClass = Convert.ToInt32(imagesByClass[i].Tag)
                });
                dataTable.Rows[i]["Euclid"] = distance;
            }

            return recognitionEngine.Recognition(distances);

        }

        public List<Bitmap> GetImagesByClass(int classNumber)
        {
            return imagesByClass.Where(obj => Convert.ToInt32(obj.Tag) == classNumber).ToList();
        } 
    }
}
