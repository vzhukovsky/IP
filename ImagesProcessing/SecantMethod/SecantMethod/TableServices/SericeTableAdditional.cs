using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SecantMethod.TableAdditional;
using SecantMethod.TableKoeffecientPlockosty;
using SecantMethod.TableRank;
using SecantMethod.TableSign;

namespace SecantMethod.TableServices
{
    public class SericeTableAdditional
    {
        private static DataGridView _grid;
        private static List<RankTable> _rankTables;
        private static List<KoeffecientPlockostyTable> _koeffecientPlockostyTables;
        private static List<SignTable> _signTables;
        private static List<AdditionalTable> _additionalTables;

        public SericeTableAdditional(DataGridView grid, List<RankTable> rankTables,
            List<KoeffecientPlockostyTable> koeffecientPlockostyTables,
            List<SignTable> signTables)
        {
            _grid = grid;
            _rankTables = rankTables;
            _koeffecientPlockostyTables = koeffecientPlockostyTables;
            _signTables = signTables;
            _additionalTables = new List<AdditionalTable>();
        }

        public List<AdditionalTable> AdditionalTables
        {
            get { return _additionalTables; }
            set { _additionalTables = value; }
        }

        public void CreateTable()
        {
            CreateHeaderTable(_koeffecientPlockostyTables.Count + 1);
        }

        private static void CreateHeaderTable(int countColumn)
        {
            _grid.ColumnCount = countColumn;
            _grid.ColumnHeadersVisible = true;
            _grid.RowHeadersVisible = true;

            var columnHeaderStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Beige,
                Font = new Font("Verdana", 10, FontStyle.Bold)
            };

            _grid.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            for (int i = 0; i < _grid.ColumnCount; i++)
            {
                _grid.Columns[i].Width = 60;
            }

            _grid.Columns[0].Name = "N";
            _grid.Columns[1].Name = "Class";

            for (var i = 0; i < _koeffecientPlockostyTables.Count - 1; i++)
            {
                _grid.Columns[i + 2].Name = string.Format("{0}", _koeffecientPlockostyTables[i].NumberPloskosty);
            }
        }

        public void SetValues()
        {
            var lastPloskost = _koeffecientPlockostyTables.Last().NumberPloskosty;

            for (int i = 0; i < _rankTables.Count; i++)
            {
                var additionalRank = new AdditionalTable
                {
                    Class = _rankTables[i].Class,
                    NumberImage = _rankTables[i].NumberImage
                };

                foreach (var keyValuePair in _rankTables[i].DictionaryRank)
                {
                    if (keyValuePair.Key == lastPloskost)
                    {
                        break;
                    }

                    if (additionalRank.DictionaryAdditionalRank == null)
                    {
                        additionalRank.DictionaryAdditionalRank = new Dictionary<int, int>();
                    }

                    if (keyValuePair.Value == 1)
                    {
                        additionalRank.DictionaryAdditionalRank[keyValuePair.Key] = 2;

                    }

                    if (keyValuePair.Value == 0)
                    {
                        if (_signTables[i].DictionaryPloskostei[keyValuePair.Key] == 0)
                        {
                            additionalRank.DictionaryAdditionalRank[keyValuePair.Key] = 0;
                        }
                        else
                        {
                            additionalRank.DictionaryAdditionalRank[keyValuePair.Key] = 1;
                        }
                    }
                }
                _additionalTables.Add(additionalRank);

            }
        }

        public void DisplayValues()
        {
            _grid.Rows.Add();

            for (int j = 0; j < _rankTables.Count; j++)
            {
                _grid[0, j].Value = _additionalTables[j].NumberImage;
                _grid[1, j].Value = _additionalTables[j].Class;
                _grid.Rows.Add();
            }

            for (int i = 0; i < _grid.RowCount - 2; i++)
            {
                var j = 2;

                foreach (var valueSign in _additionalTables[i].DictionaryAdditionalRank.Values)
                {
                    _grid[j, i].Value = valueSign;
                    j++;
                }

                j = 2;
            }
        }

        private static List<Tuple<string, string, int>> CalculationDifferentRow(Tuple<string, string, int> tuple)
        {
            var listResult = new List<Tuple<string, string, int>>();

            string splitString = null;

            var countOneZeroValues = tuple.Item2.Count(x => x == '2');

            for (int i = 0; i < countOneZeroValues; i++)
            {
                string value = tuple.Item2;
                var count = 0;
                string resultString = null;

                for (int j = 0; j < value.Count(); j++)
                {
                    if (value[j] == '2')
                    {
                        if (count == i)
                        {
                            resultString += 0;
                        }
                        else
                        {
                            resultString += 1;
                        }

                        count++;
                    }
                    else
                    {
                        resultString += value[j];
                    }
                }

                listResult.Add(new Tuple<string, string, int>(tuple.Item1, resultString, tuple.Item3));


            }
            string replaceAllOneZeroOnZero = null;

            if (countOneZeroValues == 1)
            {
                replaceAllOneZeroOnZero = tuple.Item2.Replace('2', '1');
            }
            else
            {
                replaceAllOneZeroOnZero = tuple.Item2.Replace('2', '0');
            }

            listResult.Add(new Tuple<string, string, int>(tuple.Item1, replaceAllOneZeroOnZero, tuple.Item3));

            return listResult;
        }

        public List<int> FindApponetsAdditionlTable(List<Tuple<string, string, int>> listAdditional)
        {
            var apponetsList = new List<int>();

            var list = new List<Tuple<string, string, int>>();

            for (int i = 0; i < listAdditional.Count; i++)
            {
                var listDifferentCombinationI = CalculationDifferentRow(listAdditional[i]);

                for (int j = i + 1; j < listAdditional.Count; j++)
                {
                    var listDefferentCombnationJ = CalculationDifferentRow(listAdditional[j]);

                    var flagFindApponets = false;

                    for (int i1 = 0; i1 < listDifferentCombinationI.Count; i1++)
                    {
                        for (int k = 0; k < listDefferentCombnationJ.Count; k++)
                        {
                            if (listDifferentCombinationI[i1].Item2 == listDefferentCombnationJ[k].Item2)
                            {
                                if (listDifferentCombinationI[i1].Item1 != listDefferentCombnationJ[k].Item1)
                                {
                                    apponetsList.Add(listDifferentCombinationI[i1].Item3);
                                    apponetsList.Add(listDefferentCombnationJ[k].Item3);
                                    flagFindApponets = true;
                                    break;
                                }
                            }
                        }
                        if (flagFindApponets)
                        {
                            break;
                        }
                    }
                }
            }

            return apponetsList;
        }
    }
}

