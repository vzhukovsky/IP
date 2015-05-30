using System.Collections.Generic;

namespace SecantMethod.TableKoeffecientPlockosty
{
    public class KoeffecientPlockostyTable
    {
        public int NumberPloskosty { get; set; }

        public Dictionary<int, int> DictionaryLamda { get; set; }
        public double LamdaPlus1 { get; set; }
        public double S1 { get; set; }
        public double S2 { get; set; }
        public string BetweenPoints { get; set; }
    }
}