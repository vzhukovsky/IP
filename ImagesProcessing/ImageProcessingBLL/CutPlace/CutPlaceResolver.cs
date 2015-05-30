using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using SecantMethod.Services;
using SecantMethod.TableKoeffecientPlockosty;
using SecantMethod.TablePriznakov;
using SecantMethod.TableRank;
using SecantMethod.TableServices;
using SecantMethod.TableSign;

namespace ImageProcessingBLL.CutPlace
{
    public class CutPlaceResolver
    {
        private ServiceTablePriznakov _tablePriznak;
        private ServiceTableKoeff _tableKoeff;
        private List<PriznakTable> _values;
        private int metricsCount = 6;

        public CutPlaceResolver(int metricsCount)
        {
            this.metricsCount = metricsCount;
        }

        private void CreateTablePriznakov(DataGridView dataGridView)
        {
            var listPriznakovHeader = new List<string>
            {
                "No",
                "class"
            };

            for (var i = 0; i < metricsCount; i++)
            {
                listPriznakovHeader.Add(string.Format("P{0}", i + 1));
            }

            _tablePriznak = new ServiceTablePriznakov(metricsCount, listPriznakovHeader, dataGridView);
            _tablePriznak.BuildGrid();
        }

        private void CreateTablePloskostei(DataGridView coeffTable)
        {
            var listKoefficientHeader = new List<string>
            {
                "No",
                "BetweenPoints"
            };

            for (var i = 0; i < metricsCount; i++)
            {
                listKoefficientHeader.Add(string.Format("L{0}", i + 1));
            }

            listKoefficientHeader.Add("L+1");
            listKoefficientHeader.Add("S1");
            listKoefficientHeader.Add("S2");


            _tableKoeff = new ServiceTableKoeff(metricsCount, listKoefficientHeader, coeffTable);
            _tableKoeff.BuildGrid();
            _tableKoeff.AddValueTable(ServiceTableSigns.KoeffecientPlockosty);
        }

        private static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }

        private List<PriznakTable> GetNormalizePriznaks(List<PriznakTable> priznakTables)
        {
            var countPriznaks = priznakTables.Select(x => x.Priznaki.Count).First();

            for (int i = 0; i < countPriznaks; i++)
            {
                var key = (i + 1).ToString();
                var max = priznakTables.Max(x => x.Priznaki[key]);
                var min = priznakTables.Min(x => x.Priznaki[key]);

                for (int j = 0; j < priznakTables.Count; j++)
                {
                    priznakTables[j].Priznaki[key] = (priznakTables[j].Priznaki[key] - min + 0.0) / (max - min);
                }
            }

            return priznakTables;
        }

        public void MethodSek(List<PriznakTable> values, DataGridView coeffTable,
            DataGridView signTable, DataGridView reduceTable, DataGridView rankTable, DataGridView additionalTable, DataGridView metricsTable 
            )
        {
            CreateTablePriznakov(metricsTable);
            _tablePriznak.AddValueTable(values);

            var deepClone = (List<PriznakTable>)DeepClone(values);

            var normalizePriznaks = GetNormalizePriznaks(deepClone);

            //            values = normalizePriznaks;

            //CreateTablePriznakov(dataGridView1);
            _tablePriznak.AddValueTable(normalizePriznaks);

            KoeffecientPlockostyTable koeffPloskosty = Ploskosti.GetKoefPloskosty(values, new List<KoeffecientPlockostyTable>());

            List<SignTable> listSignTables = Sings.SetupValues(values, koeffPloskosty);
            var koeffecientPlockostyTables = new List<KoeffecientPlockostyTable>() { koeffPloskosty };

            var signService = new ServiceTableSigns(signTable, koeffecientPlockostyTables, listSignTables, values);

            //Начинаем с  3 точки добавлять в таблицу знаков 
            for (var i = 2; i < values.Count; i++)
            {
                ServiceTableSigns.AddPriznak(values[i]);
            }

            //find apponets 
            while (ServiceTableSigns.FindOpponents() != null)
            {
                ServiceTableSigns.FindApponetsFinal();
            }

            ServiceTableSigns.BuildTable();

            ServiceTableSigns.SokrashSignTable();

            var signServiceSokrash = new ServiceTableSigns(reduceTable, koeffecientPlockostyTables, listSignTables, values);
            ServiceTableSigns.BuildTable();


            CreateTablePloskostei(coeffTable);


            var serviceRank = new ServiceTableRank(rankTable, additionalTable, listSignTables, koeffecientPlockostyTables);
            ServiceTableRank.CreateTable();

            ServiceTableRank.CalculatioRank();
            ServiceTableRank.DisplayValues();

            //////////////////////////////////
            ServiceTableRank.DeleteIdenticRow();
            reduceTable.Rows.Clear();
            reduceTable.Refresh();
            ServiceTableSigns.BuildTable();
            /////////////////////////////////

            ServiceTableSigns.DisplayZnazhRazr();
        }

        public string Recognition(PriznakTable priznak, DataGridView reduceSignTable)
        {
            ServiceTableSigns.AddPointInTableSing(priznak);


            SignTable current = ServiceTableSigns.SignTables.Last();

            string q = null;
            foreach (var a in current.DictionaryPloskostei)
            {
                q += a.Value;
            }

            //label2.Text = q;

            for (int i = 0; i < reduceSignTable.RowCount - 2; i++)
            {
                string splitStringOne = null;
                string splitStringTWo = null;

                for (int j = 2; j < reduceSignTable.ColumnCount; j++)
                {
                    Color backColor = reduceSignTable[j, i].Style.BackColor;

                    if (backColor == Color.Green)
                    {
                        splitStringOne += reduceSignTable[j, i].Value;
                        splitStringTWo += current.DictionaryPloskostei[Convert.ToInt32(reduceSignTable.Columns[j].HeaderText)];
                    }
                }

                if (splitStringOne == splitStringTWo)
                {
                    return ServiceTableSigns.SignTables[i].Class;

                }
            }

            return "Unrecognizable";
        }
    }
}
