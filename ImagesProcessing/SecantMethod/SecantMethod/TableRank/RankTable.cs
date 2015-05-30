using System.Collections.Generic;

namespace SecantMethod.TableRank
{
    public class RankTable
    {
        public int NumberImage { get; set; }
        public string @Class { get; set; }
        public Dictionary<int, int> DictionaryRank { get; set; }

        public int IsDeleted { get; set; }
    }
}