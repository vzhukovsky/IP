using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecantMethod.TablePriznakov;

namespace SecantMethod.TableServices
{
    public class ServiceTablePriznakov : ServiceTableBase<PriznakTable>
    {
        public ServiceTablePriznakov(int countColum, List<string> listHeaders, DataGridView grid)
            : base(countColum + 2, listHeaders, grid)
        {
        }


        public override void AddValueTable(List<PriznakTable> listValues)
        {
            for (int i = 0; i < listValues.Count; i++)
            {
                Grid.Rows.Add();

                Grid[0, i].Value = listValues[i].Number;
                Grid[1, i].Value = listValues[i].Class;

                var j = 2;

                foreach (var priznakTable in listValues[i].Priznaki)
                {
                    Grid[j, i].Value = priznakTable.Value;
                    j++;
                }
            }
        }


        protected override PriznakTable GetRowValues(int row, int col)
        {

            var tablePriznak = new PriznakTable
            {
                Number = Convert.ToInt32(Grid[0, row].Value),
                Class = Grid[1, row].Value as string,
                Priznaki = new Dictionary<string, double>()
            };

            for (var i = 2; i < col; i++)
            {
                tablePriznak.Priznaki.Add((i - 1).ToString(), Convert.ToInt32(Grid[i, row].Value));
            }

            return tablePriznak;
        }

    }
}


