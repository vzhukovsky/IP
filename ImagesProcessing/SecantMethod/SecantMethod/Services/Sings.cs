using System.Collections.Generic;
using SecantMethod.TableKoeffecientPlockosty;
using SecantMethod.TablePriznakov;
using SecantMethod.TableSign;

namespace SecantMethod.Services
{
    public static class Sings
    {
        public static List<SignTable> SetupValues(List<PriznakTable> listPriznakTable, KoeffecientPlockostyTable koeff)
        {
            var firstObject = listPriznakTable[0];
            var secondObject = listPriznakTable[1];

            var sign = CalculateSign(koeff, "1");
            var sign2 = CalculateSign(koeff, "2");

            var listSignValues = new List<SignTable>();

            var signTable = new SignTable()
            {
                Class = firstObject.Class,
                BetweenPoints = koeff.BetweenPoints,
                DictionaryPloskostei = new Dictionary<int, int>(),
                NumberImage = firstObject.Number
            };

            signTable.DictionaryPloskostei.Add(1, sign);

            listSignValues.Add(signTable);

            var signTable1 = new SignTable()
            {
                Class = secondObject.Class,
                BetweenPoints = koeff.BetweenPoints,
                DictionaryPloskostei = new Dictionary<int, int>(),
                NumberImage = secondObject.Number
            };

            signTable1.DictionaryPloskostei.Add(1, sign2);

            listSignValues.Add(signTable1);

            return listSignValues;
        }

        public static int CalculateSign(KoeffecientPlockostyTable koeff,string point)
        {
            if (point == "1")
            {
                var sign = koeff.S1 - koeff.LamdaPlus1;
                return sign > 0 ? 1 : 0;
            }
            else
            {
                var sign = koeff.S2 - koeff.LamdaPlus1;
                return sign > 0 ? 1 : 0;
            }
            
        }
    }
}