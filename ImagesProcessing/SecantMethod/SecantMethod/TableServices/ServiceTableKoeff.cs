using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecantMethod.TableKoeffecientPlockosty;

namespace SecantMethod.TableServices
{
    public class ServiceTableKoeff : ServiceTableBase<KoeffecientPlockostyTable>
    {
        public ServiceTableKoeff(int countColum, List<string> listHeaders, DataGridView grid)
            : base(countColum + 6, listHeaders, grid)
        {
        }


        protected override KoeffecientPlockostyTable GetRowValues(int row, int col)
        {
            throw new NotImplementedException();
        }

        public override void AddValueTable(List<KoeffecientPlockostyTable> listValues)
        {
            for (int i = 0; i < listValues.Count; i++)
            {
                Grid.Rows.Add();

                Grid[0, i].Value = listValues[i].NumberPloskosty;
                Grid[1, i].Value = listValues[i].BetweenPoints;

                var j = 2;

                foreach (var lamdaTable in listValues[i].DictionaryLamda)
                {
                    Grid[j, i].Value = lamdaTable.Value;
                    j++;
                }
                Grid[j++, i].Value = listValues[i].LamdaPlus1;
                Grid[j++, i].Value = listValues[i].S1;
                Grid[j, i].Value = listValues[i].S2;

                j = 0;
            }
        }
    }

}


