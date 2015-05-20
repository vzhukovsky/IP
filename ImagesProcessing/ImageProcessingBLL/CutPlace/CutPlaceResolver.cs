using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ImageProcessingBLL.CutPlace
{
    public class CutPlaceResolver
    {
        private readonly List<object>[] signs;
        private readonly Random numberGenerator = new Random();
        private readonly int size;

        private List<object>[] lambda;
        private List<object>[] r;
        private List<object> rAverage; 


        public CutPlaceResolver(params List<object>[] signs)
        {
            if (!IsValidSigns(signs))
            {
                throw new InvalidEnumArgumentException();
            }

            this.signs = signs;
            size = signs.FirstOrDefault().Count;

            lambda = GenerateLambda();
            r = GenerateR();
            rAverage = GenerateRaverage();
        }

        private bool IsValidSigns(List<object>[] signs)
        {
            return signs != null && signs.Length > 0;
        }

        private bool IsValidLambda(List<object>[] lambda)
        {
            return lambda.Length == signs.Length;
        }

        private List<object> GenerateRandomLamdaList(int size)
        {
            var lamda = new List<object>();

            for (int i = 0; i < size; i++)
            {
                lamda.Add((double)(numberGenerator.Next(-10, 10)) / 10);
            }

            return lamda;
        }

        private List<object>[] GenerateLambda()
        {
            var lamda = new List<object>[signs.Length];

            for (int i = 0; i < lamda.Length; i++)
            {
                lamda[i] = GenerateRandomLamdaList(size);
            }

            return lamda;
        }

        private List<object>[] GenerateR()
        {
            if (IsValidLambda(lambda))
            {
                var r = new List<object>[lambda.Length];
                for (int i = 0; i < r.Length; i++)
                {
                    r[i] = new List<object>();
                    
                    for (int j = 0; j < lambda.Length; j++)
                    {
                        r[i].Add(MulLists(lambda[j], signs[i]));
                    }
                         
                }
                return r;
            }

            throw new InvalidOperationException();
        }

        private double MulLists(List<object> first, List<object> second)
        {
            if (first.Count == second.Count)
            {
                double mul = 1.0;

                for (int i = 0; i < first.Count; i++)
                {
                    mul += Convert.ToDouble(first[i]) * Convert.ToDouble(second[i]);
                }
                return mul;
            }

            throw new InvalidOperationException();
        }

        private List<object> GenerateRaverage()
        {
            var rAverage = new List<object>();

            foreach (var item in r)
            {
                rAverage.Add(item.Average(obj => Convert.ToDouble(obj)));
            }

            return rAverage;
        } 
    }
}
