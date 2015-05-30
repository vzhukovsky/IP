using System.Collections.Generic;
using System.Linq;
using SecantMethod.TablePriznakov;
using SecantMethod.TableSign;

namespace SecantMethod.Services
{
    public class Priznak
    {
        public static List<PriznakTable> GetPriznaks(List<PriznakTable> priznakTables,
            List<SignTable> signApponentsTables)
        {
            var listPriznak = new List<PriznakTable>();
            var numbers = signApponentsTables.Select(x => x.NumberImage).ToList();

            for (int i = 0; i < 2; i++)
            {
                PriznakTable priznaksElement = priznakTables.Where(x => x.Number == numbers[i]).Select(x => x).First();
                listPriznak.Add(priznaksElement);
            }

            return listPriznak;
        }
    }
}