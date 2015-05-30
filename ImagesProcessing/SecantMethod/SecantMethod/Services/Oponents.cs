using System.Collections.Generic;
using System.Linq;
using SecantMethod.TablePriznakov;

namespace SecantMethod.Services
{
    public static class Oponents
    {
        public static List<PriznakTable> Find(List<PriznakTable> priznaks)
        {
            var first = priznaks.First();

            var priznakTables = priznaks.Select(x => x).FirstOrDefault(x => x.Class != first.Class);

            return new List<PriznakTable>()
            {
                first,
                priznakTables
            };
        }
    }
}