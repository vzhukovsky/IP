using System.Collections.Generic;

namespace SecantMethod.TableSign
{
    public class SignTable
    {
        public int NumberImage { get; set; }
        public string @Class { get; set; }
        public Dictionary<int, int> DictionaryPloskostei { get; set; }

        public string BetweenPoints { get; set; }

        public int IsDeleted { get; set; }

    }
}