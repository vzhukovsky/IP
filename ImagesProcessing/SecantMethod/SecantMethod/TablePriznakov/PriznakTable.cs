using System;
using System.Collections.Generic;

namespace SecantMethod.TablePriznakov
{
    [Serializable]
    public class PriznakTable
    {
        public int Number { get; set; }
        public string @Class { get; set; }

        public Dictionary<string, double> Priznaki { get; set; }

        public static void OrderMetrics(List<PriznakTable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Number = i + 1;
                items[i].Class = Convert.ToChar(i + 65).ToString();
            }
        }
    }
}