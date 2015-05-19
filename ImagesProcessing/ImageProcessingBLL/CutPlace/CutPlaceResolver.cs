using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ImageProcessingBLL.CutPlace
{
    public class CutPlaceResolver
    {
        private readonly List<object>[] signs;
        private readonly int size;

        private List<object>[] lambda;
        private const int lambdaLowLimit = -1;
        private const int lambdaHighLimit = 1;


        public CutPlaceResolver(params List<object>[] signs)
        {
            // TODO: need chech signs validity
            if (!isValidSigns(signs))
            {
                throw new InvalidEnumArgumentException();
            }

            this.signs = signs;
            size = signs.FirstOrDefault().Count;

            lambda = GenerateLambda(signs);
        }

        private bool isValidSigns(List<object>[] signs)
        {
            return signs != null && signs.Length > 0;
        }

        private List<object> GenerateRandomLamdaList(int size)
        {
            var lamda = new List<object>();
            var generator = new Random();

            for (int i = 0; i < size; i++)
            {
                lamda.Add((double)(generator.Next(-10, 10)) / 10);
            }

            return lamda;
        }

        private List<object>[] GenerateLambda(List<object>[] signs)
        {
            var lamda = new List<object>[signs.Length];

            for (int i = 0; i < lamda.Length; i++)
            {
                lamda[i] = GenerateRandomLamdaList(size);
            }

            return lamda;
        }

      
    }
}
