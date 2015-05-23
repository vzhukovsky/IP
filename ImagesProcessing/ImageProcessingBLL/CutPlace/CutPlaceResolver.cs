using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private List<object>[] signsTable;


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
            signsTable = GenerateSignsTable();
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

        private List<object>[] GenerateSignsTable()
        {
            var signsTable = new List<object>[signs.Length];

            for (int i = 0; i < signsTable.Length; i++)
            {
                signsTable[i] = new List<object>();

                for (int j = 0; j < r[i].Count; j++)
                {
                    if (Convert.ToDouble(r[i][j]) - Convert.ToDouble(rAverage[i]) < 0.0)
                    {
                        signsTable[i].Add(0);
                    }
                    else
                    {
                        signsTable[i].Add(1);
                    }
                }
            }

            return signsTable;
        }

        private void InitLambdaTableColumns(DataTable dataTable)
        {
            for (int i = 0; i < size; i++)
            {
                dataTable.Columns.Add("L" + (i + 1));
            }

            dataTable.Columns.Add("L n + 1");

            for (int i = 0; i < lambda.Length; i++)
            {
                dataTable.Columns.Add("R" + (i + 1));
            }
        }
        public DataTable GetLambdaTable()
        {
            DataTable data = new DataTable();
            InitLambdaTableColumns(data);

            for (int i = 0; i < lambda.Length; i++)
            {
                var items = new List<object>();
                items.AddRange(lambda[i]);
                items.Add(rAverage[i]);
                items.AddRange(r[i]);
                data.Rows.Add(items.ToArray());
            }

            return data;
        }

        private void InitSignsTableColumns(DataTable dataTable)
        {
            for (int i = 0; i < lambda.Length; i++)
            {
                dataTable.Columns.Add((i + 1).ToString());
            }
        }

        public DataTable GetSignsTable()
        {
            DataTable data = new DataTable();
            InitSignsTableColumns(data);

            for (int i = 0; i < signsTable.Length; i++)
            {
                data.Rows.Add(signsTable[i].ToArray());
            }

            return data;
        }
    }
}
