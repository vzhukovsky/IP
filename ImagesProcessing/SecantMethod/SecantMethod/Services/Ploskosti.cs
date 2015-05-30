using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SecantMethod.TableKoeffecientPlockosty;
using SecantMethod.TablePriznakov;
using SecantMethod.TableSign;

namespace SecantMethod.Services
{
    public static class Ploskosti
    {
        public static KoeffecientPlockostyTable GetKoefPloskosty(List<PriznakTable> priznakTables,
            List<KoeffecientPlockostyTable> koeffecientPlockostyTables)
        {
            var countPriznaks = priznakTables.First().Priznaki.Count;

            var koefPloskosty = new KoeffecientPlockostyTable();
            var random = new Random((int)DateTime.Now.Ticks);
            koefPloskosty.DictionaryLamda = new Dictionary<int, int>();

            for (int i = 0; i < countPriznaks; i++)
            {
                //                Thread.Sleep(1000);
                var value = random.Next(-100, 100);
                koefPloskosty.DictionaryLamda.Add(i + 1, value);
            }

            List<PriznakTable> oppents = Oponents.Find(priznakTables);


            var sums = CalculateSum(oppents, koefPloskosty.DictionaryLamda);
            var lamdaPlusOne = GetlamdaPlusOne(sums);

            koefPloskosty.S1 = sums[0];
            koefPloskosty.S2 = sums[1];

            koefPloskosty.LamdaPlus1 = lamdaPlusOne;
            koefPloskosty.BetweenPoints = string.Format("{0}/{1}", oppents[0].Number, oppents[1].Number);

            koefPloskosty.NumberPloskosty = 1;


            return koefPloskosty;
        }

        private static List<double> CalculateSum(List<PriznakTable> oppents, Dictionary<int, int> dictionaryKoeff)
        {
            var s1 = 0.0;
            var s2 = 0.0;

            var valuesOpponentsFirs = oppents[0].Priznaki.Select(x => x.Value).ToList();
            var valuesOpponentsTwo = oppents[1].Priznaki.Select(x => x.Value).ToList();
            var valueKoeff = dictionaryKoeff.Values.ToList();

            var resultCalculationSum = new List<double>();

            for (var i = 0; i < valueKoeff.Count; i++)
            {
                s1 += valueKoeff[i] * valuesOpponentsFirs[i];
                s2 += valueKoeff[i] * valuesOpponentsTwo[i];
            }

            resultCalculationSum.Add(s1);
            resultCalculationSum.Add(s2);

            return resultCalculationSum;
        }


        private static double GetlamdaPlusOne(IReadOnlyList<double> sumsList)
        {
            var random = new Random((int)DateTime.Now.Ticks);

            if (sumsList[0] < sumsList[1])
            {
                return random.NextDouble() * (sumsList[1] - sumsList[0]) + sumsList[0];
            }
            else
            {
                return random.NextDouble() * (sumsList[0] - sumsList[1]) + sumsList[1];
            }

        }



        public static KoeffecientPlockostyTable CreateNewPloskost(List<PriznakTable> priznakFindedTables,
            List<SignTable> signTables,
            List<KoeffecientPlockostyTable> koeffecientPlockostyTables)
        {
            var countPriznaks = priznakFindedTables.First().Priznaki.Count;

            var koefPloskosty = new KoeffecientPlockostyTable();
            var random = new Random((int)DateTime.Now.Ticks);
            koefPloskosty.DictionaryLamda = new Dictionary<int, int>();

            for (int i = 0; i < countPriznaks; i++)
            {
                var value = random.Next(-100, 100);
                koefPloskosty.DictionaryLamda.Add(i + 1, value);
                Thread.Sleep(20);
            }

            var sums = CalculateSum(priznakFindedTables, koefPloskosty.DictionaryLamda);
            var lamdaPlusOne = GetlamdaPlusOne(sums);

            koefPloskosty.S1 = sums[0];
            koefPloskosty.S2 = sums[1];

            koefPloskosty.LamdaPlus1 = lamdaPlusOne;
            koefPloskosty.BetweenPoints = string.Format("{0}/{1}", signTables[0].NumberImage, signTables[1].NumberImage);

            koefPloskosty.NumberPloskosty = koeffecientPlockostyTables.Count + 1;

            koeffecientPlockostyTables.Add(koefPloskosty);
            return koefPloskosty;
        }
    }
}